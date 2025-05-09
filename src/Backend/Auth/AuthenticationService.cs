using IdentityModel.Client;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TrackingSystem.Backend.Entities;
using TrackingSystem.DataModel;

namespace TrackingSystem.Backend.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IdentitySettings _identitySettings;
        readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(IOptions<IdentitySettings> options, ILogger<AuthenticationService> logger)
        {
            this._logger = logger;
            _identitySettings = options.Value;
        }
        public async Task<AccessToken?> GenerateTokenAsync(string email, string password)
        {
            _logger?.LogInformation("Token requested for {email}", email);

            using var client = new HttpClient();

            var disco = await GetDicovertyDocumentAsync(client).ConfigureAwait(false);

            if (!disco.IsError)
            {
                _logger?.LogInformation("Discovery document retrieved successfully, requesting token for {email}", email);

                var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = _identitySettings.ClientID,
                    ClientSecret = _identitySettings.ClientSecret,
                    Scope = "email offline_access",
                    UserName = email,
                    Password = password
                }).ConfigureAwait(false);


                if (tokenResponse.Json == null || tokenResponse.IsError)
                {
                    _logger?.LogError("Token request failed: {error}", tokenResponse.Error);
                    return null;
                }

                _logger?.LogInformation("Token retrieved successfully for {email}", email);

                return tokenResponse.Json.Value.Deserialize<AccessToken>();
            }

            _logger?.LogError("Discovery document retrieval failed: {error}", disco.Error);

            return null;
        }

        public async Task<AccessToken?> GenerateTokenFromRefreshTokenAsync(string refreshToken)
        {
            using var client = new HttpClient();
            var disco = await GetDicovertyDocumentAsync(client).ConfigureAwait(false);

            if (!disco.IsError)
            {
                var tokenResponse = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = _identitySettings.ClientID,
                    ClientSecret = _identitySettings.ClientSecret,
                    RefreshToken = refreshToken
                }).ConfigureAwait(false);


                if (tokenResponse.Json == null || tokenResponse.IsError)
                {
                    return null;
                }
                return tokenResponse.Json.Value.Deserialize<AccessToken>();
            }

            return null;
        }

        private async Task<DiscoveryDocumentResponse> GetDicovertyDocumentAsync(HttpClient client)
        {
            return await client
                .GetDiscoveryDocumentAsync(
                    new DiscoveryDocumentRequest
                    {
                        Address = _identitySettings.ServerURL,
                        Policy = {
                        ValidateIssuerName = false,
                        ValidateEndpoints = false,
                        RequireHttps = false
                        }
                    }
                )
                .ConfigureAwait(false);
        }
    }
}
