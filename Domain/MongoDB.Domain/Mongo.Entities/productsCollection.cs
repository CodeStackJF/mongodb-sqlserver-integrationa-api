using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Domain.Mongo.Entities
{
    public class productsCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public int id_product { get; set; }
        public string? name { get; set; }
        public ICollection<categoriesCollection>? categories { get; set; }
        public ICollection<suppliersCollection>? suppliers { get; set; }
    }
}