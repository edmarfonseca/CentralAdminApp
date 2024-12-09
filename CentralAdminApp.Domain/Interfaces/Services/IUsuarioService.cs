using CentralAdminApp.Domain.Dtos;

namespace CentralAdminApp.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        CriarUsuarioResponse CriarUsuario(CriarUsuarioRequest dto);
        AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest dto);
    }
}