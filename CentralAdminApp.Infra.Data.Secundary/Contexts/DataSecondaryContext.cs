using CentralAdminApp.Infra.Data.Secondary.Settings;
using MongoDB.Driver;

namespace CentralAdminApp.Infra.Data.Secondary.Contexts
{
    public class DataSecondaryContext<T> where T : class
    {
        private readonly IMongoDatabase? _database;
        private readonly string? _collectionName;

        public DataSecondaryContext(string collectionName)
        {
            var clientSettings = MongoClientSettings.FromUrl(new MongoUrl(DataSecondaryContextSettings.Host));
            var mongoClient = new MongoClient(clientSettings);

            _database = mongoClient.GetDatabase(DataSecondaryContextSettings.Database);
            _collectionName = collectionName;
        }

        public IMongoCollection<T>? Collection
        {
            get
            {
                return _database?.GetCollection<T>(_collectionName);
            }
        }
    }
}