using MongoDB.Driver;
using twelvefactors_anwar.Entities;

namespace twelvefactors_anwar.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
