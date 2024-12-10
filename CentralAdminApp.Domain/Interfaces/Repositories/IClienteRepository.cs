using CentralAdminApp.Domain.Entities;

namespace CentralAdminApp.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        bool Verify(string cpfCnpj, int clienteId);
    }
}