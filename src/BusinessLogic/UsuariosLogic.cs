using TrackingSystem.BusinessLogic.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem.BusinessLogic.Auth;
using TrackingSystem.BusinessLogic.Entities;
using TrackingSystem.BusinessLogic.Entities.Responses;
using TrackingSystem.BusinessLogic.Entities.Inputs;
using TrackingSystem.DataModel;

namespace TrackingSystem.BusinessLogic
{
    public class UsuariosLogic : IUsuariosLogic
    {
        private readonly TrackingDataContext _context;
        readonly ILogger? _logger;

        public UsuariosLogic(
            TrackingDataContext context,
            ILogger<UsuariosLogic>? logger = null)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UsuarioResponse> RegistrarAsync(NuevoUsuarioInput nuevoUsuario, CancellationToken cancellationToken = default)
        {
            if (nuevoUsuario.Password != nuevoUsuario.ConfirmacionDePassword)
            {
                throw new SimpleException(101, "Las contraseñas no coinciden");
            }

            // Verificación Inicial - Esta prueba verifica si el email ya está registrado. Si lo está, se lanza una excepción.
            // NOTA: Puede que el email no exista en este momento y exista cuando se guarde en la BD (race condition), esto es debido a que 
            // la base de datos puede ser modificada por otros usuarios.
            // Luego en este código se verifica un código de error especifico de la BD al momento de guardar.
            var usuarioExistente = await _context.Usuarios
                .Where(m => m.Email == nuevoUsuario.Email)
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (usuarioExistente != null)
            {
                throw new SimpleException(102, "El email ya está registrado");
            }

            try
            {
                // Crear el Usuario para la BD
                var usuario = new Usuario
                {
                    Apellidos = nuevoUsuario.Apellidos,
                    Nombres = nuevoUsuario.Nombres,
                    Email = nuevoUsuario.Email,
                    PasswordHash = AuthenticationHelper.GetPasswordHash(nuevoUsuario.Password),
                    FechaDeCreacion = DateTimeOffset.Now,
                    Estado = "A"
                };

                _context.Usuarios.Add(usuario);

                // Guardarlo en la BD
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                // Crear el resultado
                var result = new UsuarioResponse
                {
                    Apellidos = usuario.Apellidos,
                    Nombres = usuario.Nombres,
                    Email = usuario.Email,
                    FechaDeCreacion = usuario.FechaDeCreacion,
                    Estado = usuario.Estado
                };

                // Retornar resultado
                return result;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx)
                {
                    if (sqlEx.Number == 2627)
                    {
                        throw new SimpleException(102, "El email ya está registrado");
                    }
                }
                throw;
            }
        }

        public async Task<UsuarioResponse?> GetUsuarioPorIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var usuario = await _context.Usuarios
                .Where(m => m.UsuarioId == id && m.Estado == "A")
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (usuario == null)
            {
                return null;
            }

            // Información básica del usuario que se agregara al auth token
            var usuarioDTO = new UsuarioResponse
            {
                UsuarioId = usuario.UsuarioId,
                Email = usuario.Email,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                FechaDeCreacion = usuario.FechaDeCreacion,
                Estado = usuario.Estado
            };

            // Retornar token
            return usuarioDTO;
        }
        public async Task<UsuarioResponse?> GetUsuarioPorEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var usuario = await _context.Usuarios
                .Where(m => m.Email == email && m.Estado == "A")
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (usuario == null)
            {
                return null;
            }

            // Información básica del usuario que se agregara al auth token
            var usuarioDTO = new UsuarioResponse
            {
                UsuarioId = usuario.UsuarioId,
                Email = usuario.Email,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                FechaDeCreacion = usuario.FechaDeCreacion,
                Estado = usuario.Estado
            };

            // Retornar token
            return usuarioDTO;
        }
    }
}
