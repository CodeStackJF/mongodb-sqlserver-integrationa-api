using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Domain.Mongo.Entities
{
    public class suppliersCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int id_supplier { get; set; }
        public string? name { get; set; }
    }
}