using CentralAdminApp.Domain.Entities;

namespace CentralAdminApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        bool Verify(string email);
        Usuario Find(string email, string senha);
    }
}