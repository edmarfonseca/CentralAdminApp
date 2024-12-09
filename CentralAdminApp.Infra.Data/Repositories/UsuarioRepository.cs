using Microsoft.EntityFrameworkCore;
using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Interfaces.Repositories;
using CentralAdminApp.Infra.Data.Contexts;

namespace CentralAdminApp.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public bool Verify(string email)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Usuario>()
                    .Any(u => u.Email.Equals(email));
            }
        }

        public Usuario? Find(string email, string senha)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Usuario>()
                    .Where(u => u.Email.Equals(email)
                             && u.Senha.Equals(senha))
                    .FirstOrDefault();
            }
        }
    }
}