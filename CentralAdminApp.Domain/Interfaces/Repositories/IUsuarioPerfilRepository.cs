using CentralAdminApp.Domain.Entities;

namespace CentralAdminApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioPerfilRepository : IRepositoryBase<UsuarioPerfil>
    {
        List<UsuarioPerfil> Get(Usuario usuario);
    }
}