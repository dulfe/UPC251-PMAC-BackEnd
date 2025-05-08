using IdentityServer8.Models;
using IdentityServer8.Validation;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TrackingSystem.DataModel;
using TrackingSystem.IdentityServer.Auth;

namespace IdentityServer.Validation
{
    public class ResourceOwnerPasswordValidatorService : IResourceOwnerPasswordValidator
    {
        private readonly TrackingDataContext _dbcontext;
        public ResourceOwnerPasswordValidatorService(TrackingDataContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var username = context.UserName;
            var password = context.Password;

            var user = await CheckCredentialsAsync(username, password);
            if (user == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
                return;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nombres),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString())
            };
            context.Result = new GrantValidationResult(user.UsuarioId.ToString(), "password", claims);
            context.Request.Client.AlwaysSendClientClaims = true;
            
            return;
        }

        public async Task<Usuario?> CheckCredentialsAsync(string username, string password)
        {
            var usuario = await _dbcontext.Usuarios
                .Where(m => m.Email == username && m.Estado == "A")
                .SingleOrDefaultAsync();

            if (usuario == null)
            {
                return null;
            }
            var hashedPassword = AuthenticationHelper.GetPasswordHash(password);

            if (hashedPassword != usuario.PasswordHash)
            {
                return null;
            }

            return usuario;
        }
    }
}
