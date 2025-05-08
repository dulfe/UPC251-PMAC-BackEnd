using System;
using System.Linq;
using TrackingSystem.BusinessLogic.Entities;
using TrackingSystem.BusinessLogic.Entities.Responses;
using TrackingSystem.BusinessLogic.Entities.Inputs;

namespace TrackingSystem.BusinessLogic
{
    public interface IUsuariosLogic
    {
        Task<UsuarioResponse?> GetUsuarioPorIdAsync(int id, CancellationToken cancellationToken = default);
        Task<UsuarioResponse> RegistrarAsync(NuevoUsuarioInput nuevoUsuario, CancellationToken cancellationToken = default);
        Task<UsuarioResponse?> GetUsuarioPorEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
