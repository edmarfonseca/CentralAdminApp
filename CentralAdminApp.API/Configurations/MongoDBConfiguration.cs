using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using CentralAdminApp.Domain.Entities;
using CentralAdminApp.Infra.Data.Secondary.Contexts;
using MongoDB.Driver;
using CentralAdminApp.Domain.Helpers;

namespace CentralAdminApp.API.Configurations
{
    public class MongoDBConfiguration
    {
        public static void AddMongoDBConfiguration()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(int)))
            {
                BsonSerializer.RegisterSerializer
                    (new GuidSerializer(MongoDB.Bson.BsonType.String));
            }

            var dataContext = new DataSecondaryContext<Uf>("Ufs");

            var collection = dataContext.Collection;

            if (!collection.AsQueryable().Any())
            {
                var seedData = new List<Uf>
                {
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "AC", Descricao = "Acre", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "AL", Descricao = "Alagoas", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "AP", Descricao = "Amapá", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "AM", Descricao = "Amazonas", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "BA", Descricao = "Bahia", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "CE", Descricao = "Ceará", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "DF", Descricao = "Distrito Federal", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "ES", Descricao = "Espírito Santo", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "GO", Descricao = "Goiás", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "MA", Descricao = "Maranhão", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "MT", Descricao = "Mato Grosso", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "MS", Descricao = "Mato Grosso do Sul", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "MG", Descricao = "Minas Gerais", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "PA", Descricao = "Pará", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "PB", Descricao = "Paraíba", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "PR", Descricao = "Paraná", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "PE", Descricao = "Pernambuco", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "PI", Descricao = "Piauí", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "RJ", Descricao = "Rio de Janeiro", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "RN", Descricao = "Rio Grande do Norte", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "RS", Descricao = "Rio Grande do Sul", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "RO", Descricao = "Rondônia", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "RR", Descricao = "Roraima", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "SC", Descricao = "Santa Catarina", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "SP", Descricao = "São Paulo", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "SE", Descricao = "Sergipe", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true },
                    new Uf { Id = GenerateIdHelper.NewIdFromGuid(), Sigla = "TO", Descricao = "Tocantins", DataInclusao = DateTime.Now, DataAlteracao = DateTime.Now, Ativo = true }
                };

                collection?.InsertMany(seedData);
            }
        }

    }
}