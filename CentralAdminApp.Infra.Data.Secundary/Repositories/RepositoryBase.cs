using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Domain.Interfaces.Repositories;
using CentralAdminApp.Infra.Data.Secondary.Contexts;
using MongoDB.Driver;

namespace CentralAdminApp.Infra.Data.Secondary.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DataSecondaryContext<T> _context;

        public RepositoryBase(string collectionName)
        {
            _context = new DataSecondaryContext<T>(collectionName);
        }

        public virtual T Add(T obj)
        {
            _context?.Collection?.InsertOne(obj);
            return obj;
        }

        public virtual T Update(T obj)
        {
            _context?.Collection?.ReplaceOne(Builders<T>.Filter.Eq("_id", (obj as EntityBase)?.Id), obj);
            return obj;
        }

        public virtual T Delete(T obj)
        {
            _context?.Collection?.DeleteOne(Builders<T>.Filter.Eq("_id", (obj as EntityBase)?.Id));
            return obj;
        }

        public virtual ICollection<T>? Get()
        {
            return _context?.Collection?.Find(_ => true).ToList();
        }

        public virtual T? Get(int id)
        {
            return _context?.Collection?.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefault();
        }
    }
}