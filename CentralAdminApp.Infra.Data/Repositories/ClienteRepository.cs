using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Interfaces.Repositories;

namespace CentralAdminApp.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
    }
}