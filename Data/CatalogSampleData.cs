using MongoDB.Driver;
using System.Collections.Generic;
using twelvefactors_anwar.Entities;

namespace twelvefactors_anwar.Data
{

    public class CatalogSampleData
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "111111111111111111111118",
                    Name = "iPhone X",
                    Price = 999.99M
                },
                new Product()
                {
                    Id = "111111111111111111111119",
                    Name = "Samsung Galaxy A50",
                    Price = 350.00M
                },
                new Product()
                {
                    Id = "11111111111111111111111a",
                    Name = "Huawei P30 Pro",
                    Price = 650.00M
                }
            };
        }
    }
}