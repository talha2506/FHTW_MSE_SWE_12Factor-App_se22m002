using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace twelvefactors_anwar.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {  get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
