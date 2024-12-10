using CentralAdminApp.Domain.Entities;

namespace CentralAdminApp.Domain.Interfaces.Repositories
{
    public interface ISistemaRepository : IRepositoryBase<Sistema>
    {
        bool Verify(string codigo, int sistemaId);
    }
}