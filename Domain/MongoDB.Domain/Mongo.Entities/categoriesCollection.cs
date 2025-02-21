using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Domain.Mongo.Entities;

public class categoriesCollection
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public int id_category { get; set; }
    public string? description { get; set; }
}