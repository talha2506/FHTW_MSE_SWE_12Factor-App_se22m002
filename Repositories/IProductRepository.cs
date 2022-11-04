using System.Collections.Generic;
using System.Threading.Tasks;
using twelvefactors_anwar.Entities;

namespace twelvefactors_anwar.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task CreateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }
}
