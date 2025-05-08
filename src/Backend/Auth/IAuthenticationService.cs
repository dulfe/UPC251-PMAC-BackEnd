using System;
using System.Linq;
using TrackingSystem.Backend.Entities;

namespace TrackingSystem.Backend.Auth
{
    public interface IAuthenticationService
    {
        Task<AccessToken?> GenerateTokenFromRefreshTokenAsync(string refreshToken);
        Task<AccessToken?> GenerateTokenAsync(string email, string password);
    }
}
