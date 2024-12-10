using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Interfaces.Repositories;
using CentralAdminApp.Infra.Data.Contexts;

namespace CentralAdminApp.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public bool Verify(string cpfCnpj, int clienteId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Cliente>()
                    .Any(c => c.CpfCnpj.Equals(cpfCnpj) && c.Id != clienteId && c.Ativo);
            }
        }
    }
}