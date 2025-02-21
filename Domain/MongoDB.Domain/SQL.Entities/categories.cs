using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Domain.SQL.Entities;

public class categories
{
    public int id_category { get; set; }
    public string? description { get; set; }
}