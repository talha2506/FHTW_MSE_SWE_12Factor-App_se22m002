using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using twelvefactors_anwar.Entities;

namespace twelvefactors_anwar.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var db = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = db.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogSampleData.SeedData(Products);
            
        }

        public IMongoCollection<Product> Products { get; }
    }
}
