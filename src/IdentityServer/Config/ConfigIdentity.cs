using IdentityModel;
using IdentityServer8;
using IdentityServer8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystem.IdentityServer
{
    public class ConfigIdentity
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> response = new List<ApiResource>();
            response.Add(
                new ApiResource(
                    "TRACKING-SYSTEM-API",
                    "TRACKING-SYSTEM-API",
                    new[]
                    {
                            JwtClaimTypes.Email,
                            JwtClaimTypes.Expiration,
                            JwtClaimTypes.Id,
                            JwtClaimTypes.IdentityProvider,
                            JwtClaimTypes.Name,
                            JwtClaimTypes.PhoneNumber,
                            JwtClaimTypes.SessionId,
                            JwtClaimTypes.ClientId
                    }
                    )
                { Scopes = new List<string>() { "email" } }
                );

            return response;
        }

        public static IEnumerable<Client> GetClients()
        {
            List<Client> response = new List<Client>();
            response.Add(
                    new Client()
                    {
                        ClientId = "71BB7236-C97F-46F8-A0CB-395AA0FCADDF",
                        ClientSecrets = { new Secret("AF5D9F51-276D-4D24-9E82-31A90A88C4FF".ToSha256()) },
                        AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                        AllowedScopes = { "email", IdentityServerConstants.StandardScopes.Email },
                        AllowOfflineAccess = true,
                    }
                );
            return response;
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return [
                new ApiScope(name: "email", displayName: "email"),
            ];
        }


    }
}
