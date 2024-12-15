using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Interfaces.Repositories;
using MongoDB.Driver;

namespace CentralAdminApp.Infra.Data.Secondary.Repositories
{
    public class UfRepository : RepositoryBase<Uf>, IUfRepository
    {
        public UfRepository() : base("Ufs")
        {
        }

        public bool Verify(string sigla, int ufId)
        {
            var filter = Builders<Uf>.Filter.And(
                Builders<Uf>.Filter.Eq(u => u.Sigla, sigla),
                Builders<Uf>.Filter.Ne(u => u.Id, ufId),
                Builders<Uf>.Filter.Eq(u => u.Ativo, true)
            );

            return _context.Collection.Find(filter).Any();
        }
    }
}