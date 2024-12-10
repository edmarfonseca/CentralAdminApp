using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Interfaces.Repositories;
using CentralAdminApp.Infra.Data.Contexts;

namespace CentralAdminApp.Infra.Data.Repositories
{
    public class SistemaRepository : RepositoryBase<Sistema>, ISistemaRepository
    {
        public bool Verify(string codigo, int sistemaId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Sistema>()
                    .Any(s => s.Codigo.Equals(codigo) && s.Id != sistemaId && s.Ativo);
            }
        }
    }
}