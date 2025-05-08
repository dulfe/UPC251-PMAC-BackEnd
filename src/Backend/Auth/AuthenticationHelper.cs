using System.Security.Claims;

namespace TrackingSystem.Backend.Auth
{
    public static class AuthenticationHelper
    {
        public static int GetUsuarioId(ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }
    }
}
