using CentralAdminApp.Domain.Entities;

namespace CentralAdminApp.Domain.Interfaces.Repositories
{
    public interface IUfRepository : IRepositoryBase<Uf>
    {
        bool Verify(string sigla, int ufId);
    }
}