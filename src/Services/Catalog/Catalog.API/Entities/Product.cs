using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Category { get; set; }
        public string Summery { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
