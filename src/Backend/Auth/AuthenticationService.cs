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

        public AuthenticationService(IOptions<IdentitySettings> options)
        {
            _identitySettings = options.Value;
        }
        public async Task<AccessToken?> GenerateTokenAsync(string email, string password)
        {
            using var client = new HttpClient();

            var disco = await GetDicovertyDocumentAsync(client);

            if (!disco.IsError)
            {
                var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = _identitySettings.ClientID,
                    ClientSecret = _identitySettings.ClientSecret,
                    Scope = "email offline_access",
                    UserName = email,
                    Password = password
                });


                if (tokenResponse.Json == null || tokenResponse.IsError)
                {
                    return null;
                }
                return tokenResponse.Json.Value.Deserialize<AccessToken>();
            }

            return null;
        }

        public async Task<AccessToken?> GenerateTokenFromRefreshTokenAsync(string refreshToken)
        {
            using var client = new HttpClient();
            var disco = await GetDicovertyDocumentAsync(client);

            if (!disco.IsError)
            {
                var tokenResponse = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = _identitySettings.ClientID,
                    ClientSecret = _identitySettings.ClientSecret,
                    RefreshToken = refreshToken
                });


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
                );
        }
    }
}
