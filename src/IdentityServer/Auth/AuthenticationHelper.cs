﻿using System.Security.Claims;

namespace TrackingSystem.IdentityServer.Auth
{
    public static class AuthenticationHelper
    {
        public static string UserIdClaimName = "UserId";
        public static string GetPasswordHash(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
