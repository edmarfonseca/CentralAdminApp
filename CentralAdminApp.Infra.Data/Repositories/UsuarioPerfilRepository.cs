using Microsoft.EntityFrameworkCore;
using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Interfaces.Repositories;
using CentralAdminApp.Infra.Data.Contexts;

namespace CentralAdminApp.Infra.Data.Repositories
{
    public class UsuarioPerfilRepository : RepositoryBase<UsuarioPerfil>, IUsuarioPerfilRepository
    {
        public List<UsuarioPerfil> Get(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<UsuarioPerfil>()
                    .Where(u => u.UsuarioId == usuario.Id && u.Ativo)
                    .Include(u => u.ClienteSistema)
                    .Include(u => u.ClienteSistema.Sistema)
                    .Include(u => u.Perfil)
                    .ToList();
            }
        }
    }
}