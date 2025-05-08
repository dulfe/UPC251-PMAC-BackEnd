using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TrackingSystem.Backend.Auth;
using TrackingSystem.BusinessLogic;
using TrackingSystem.BusinessLogic.Entities.Responses;

namespace TrackingSystem.Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SeguimientoDeOrdenesController : ControllerBase
    {
        readonly ILogger<SeguimientoDeOrdenesController> _logger;
        readonly ISeguimientoDeOrdenesLogic _logic;

        public SeguimientoDeOrdenesController(
            ISeguimientoDeOrdenesLogic logic,
            ILogger<SeguimientoDeOrdenesController> logger)
        {
            this._logic = logic;
            this._logger = logger;
        }

        /// <summary>
        /// Retorna las ordenes de trabajo que hay sido anteriormente consultadas por el usuario actual.
        /// </summary>
        /// <example>GET /api/SeguimientoDeOrdenes</example>
        /// <param name="cantidad">Cantidad maxima de ordenes a retornar. (Defecto: 10).</param>
        /// <returns></returns>
        [HttpGet("/api/SeguimientoDeOrdenes")]
        [ProducesResponseType<List<ResumenDeOrdenResponse>>(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ResumenDeOrdenResponse>>> GetOrdenes([FromQuery] int? cantidad)
        {
            _logger?.LogDebug("GetOrdenes:START");

            // Obtener el id del usuario actual
            var userId = AuthenticationHelper.GetUsuarioId(User);
            _logger?.LogDebug("GetOrdenes:UserId={0}", userId);

            // Recuperar las ordenes de trabajo del usuario
            var result = await _logic.GetOrdenesAsync(userId, cantidad);

            _logger?.LogDebug("GetOrdenes:OrdenPorUsuario={0}", result.Count);

            return result;
        }

        /// <summary>
        /// Retorna el detalle de una orden de trabajo por su codigo de seguimiento.
        /// </summary>
        /// <example>GET /api/SeguimientoDeOrdenes/ABC5202024</example>
        /// <param name="codigoDeSeguimiento">Codigo de seguimiento de la orden de trabajo.</param>
        /// <response code="200">Retorna el detalle de la orden de trabajo.</response>
        /// <response code="404">Si no se encuentra la orden de trabajo.</response>
        /// <returns></returns>
        [HttpGet("/api/SeguimientoDeOrdenes/{codigoDeSeguimiento}")]
        public async Task<ActionResult<DetalleDeOrdenResponse>> GetOrdenPorCodigoDeSeguimiento(string codigoDeSeguimiento)
        {
            // Recuperar el id del usuario actual
            var usuarioId = AuthenticationHelper.GetUsuarioId(User);

            // Recuperar la orden de trabajo por el código de seguimiento
            var result = await _logic.GetOrdenPorCodigoDeSeguimientoAsync(usuarioId, codigoDeSeguimiento).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        /// <summary>
        /// Elimina una orden de trabajo de la lista de seguimiento del usuario actual.
        /// </summary>
        /// <example>DELETE /api/SeguimientoDeOrdenes/ABC5202024</example>
        /// <param name="codigoDeSeguimiento">Código de seguimiento de la orden de trabajo.</param>
        /// <response code="200">Si la orden de trabajo fue eliminada.</response>
        /// <response code="404">Si no se encuentra la orden de trabajo.</response>
        /// <returns></returns>
        [HttpDelete("/api/SeguimientoDeOrdenes/{codigoDeSeguimiento}")]
        public async Task<ActionResult> DeleteOrdenPorUsuario(string codigoDeSeguimiento)
        {
            // Recuperar el id del usuario actual
            var usuarioId = AuthenticationHelper.GetUsuarioId(User);

            // Borrar la orden de trabajo
            var result = await _logic.DeleteOrdenPorUsuarioAsync(usuarioId, codigoDeSeguimiento).ConfigureAwait(false);

            // Si no se encuentra la orden de trabajo, devolver un 404
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Retorna la ubicación actual de una orden de trabajo en tiempo real. 
        /// </summary>
        /// <remarks>SIMULACION: Solo funciona con el código de seguimiento "ABC5202024"</remarks>
        /// <param name="codigoDeSeguimiento">Código de seguimiento de la orden de trabajo.</param>
        /// <response code="200">Retorna la ubicación actual de la orden de trabajo.</response>
        /// <response code="404">Si no se encuentra la orden de trabajo.</response>
        /// <returns></returns>
        [HttpGet("/api/SeguimientoDeOrdenes/{codigoDeSeguimiento}/ubicacion")]
        [ProducesResponseType<RastreoEnTiempoRealResponse>(StatusCodes.Status200OK)]
        public async Task<ActionResult<RastreoEnTiempoRealResponse>> GetUbicacionActual(string codigoDeSeguimiento)
        {
            // Recuperar el id del usuario actual
            var usuarioId = AuthenticationHelper.GetUsuarioId(User);

            // Obtener la ubicación actual
            var result = await _logic.GetUbicacionActualAsync(usuarioId, codigoDeSeguimiento).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
