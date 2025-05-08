using TrackingSystem.BusinessLogic;
using TrackingSystem.BusinessLogic.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TrackingSystem.Backend.Auth;
using TrackingSystem.Backend.Entities;
using TrackingSystem.BusinessLogic.Entities;
using TrackingSystem.BusinessLogic.Entities.Responses;
using TrackingSystem.BusinessLogic.Entities.Inputs;
using TrackingSystem.Backend.Entities.Inputs;

namespace TrackingSystem.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        readonly ILogger _logger;
        readonly IUsuariosLogic _logic;
        readonly IAuthenticationService _authenticationService;

        public UsuariosController(
            IUsuariosLogic usuariosLogic,
            IAuthenticationService authenticationService,
            ILogger<UsuariosController> logger)
        {
            this._authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService), $"{nameof(authenticationService)} is null.");
            this._logic = usuariosLogic ?? throw new ArgumentNullException(nameof(usuariosLogic), $"{nameof(usuariosLogic)} is null.");
            this._logger = logger;
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="nuevoUsuario"></param>
        /// <response code="200">Usuario registrado correctamente</response>
        /// <response code="400">Se produjo un error al crear el usuario, verifique la respuesta para mas detalles.</response>
        /// <returns></returns>
        [HttpPost("registrar")]
        [AllowAnonymous]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<SimpleError>(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Registrar(NuevoUsuarioInput nuevoUsuario)
        {
            try
            {
                var result = await _logic.RegistrarAsync(nuevoUsuario);

                return Ok(result);
            }
            catch (SimpleException ex)
            {
                return BadRequest(new SimpleError(ex.Code, ex.Message));
            }
        }

        /// <summary>
        /// Genera un token JWT para un usuario autenticado usando "oauth2" y el flujo "Resource Owner Password Credentials Grant".
        /// </summary>
        /// <param name="credenciales">Email y Password</param>
        /// <returns>JWT Token con usa expiración de 4 horas</returns>
        /// <response code="200">Usuario Autenticado</response>
        /// <response code="401">Usuario no existe o el password es incorrecto.</response>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType<AccessToken>(StatusCodes.Status200OK)]
        [ProducesResponseType<SimpleError>(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Login([FromBody] VerificarCredencialesInput credenciales)
        {
            // Obtener Token del Identity Server usando Resource Owner Password Credentials Grant
            var token = await this._authenticationService.GenerateTokenAsync(
                credenciales.Email, credenciales.Password);

            if (token == null)
            {
                return Unauthorized(new SimpleError(100, "Usuario no existe o el password es incorrecto."));
            }

            // Retornamos el Access Token
            return Ok(token);
        }

        /// <summary>
        /// Crea un nuevo Access Token y Refresh Token a partir de un Refresh Token válido.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Nuevo Auth Token</response>
        /// <response code="401">Access or Refresh Token son inválidos.</response>
        [HttpPost("refresh")]
        [AllowAnonymous]
        [ProducesResponseType<AccessToken>(StatusCodes.Status200OK)]
        [ProducesResponseType<SimpleError>(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Refresh([FromBody] TokenRefreshRequestInput model)
        {
            var result = await this._authenticationService.GenerateTokenFromRefreshTokenAsync(model.RefreshToken);

            if (result == null)
            {
                return Unauthorized(new SimpleError(101, "Refresh token es Invalido o expirado."));
            }

            return Ok(result);
        }

        /// <summary>
        /// Obtiene el usuario actualmente autenticado.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Usuario Actual</response>
        /// <response code="500">Error Interno.</response>
        [HttpGet("whoami")]
        [Authorize]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<SimpleError>(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> WhoAmI()
        {
            var userId = AuthenticationHelper.GetUsuarioId(HttpContext.User);
            var result = await this._logic.GetUsuarioPorIdAsync(userId).ConfigureAwait(false);

            if (result == null)
            {
                // Esto nunca debería pasar, pero si pasa, es un error interno.
                return StatusCode(500, new SimpleError(500, "El usuario actual no se pudo obtener."));
            }

            return Ok(result);
        }

        /// <summary>
        /// Genera un error de prueba. Usado para verificar que el filtro global de manejo de errores funciona correctamente.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("generarerror")]
        public IActionResult GenerarErrorDePrueba()
        {
            throw new Exception("Este es un error de prueba.");
        }
    }
}
