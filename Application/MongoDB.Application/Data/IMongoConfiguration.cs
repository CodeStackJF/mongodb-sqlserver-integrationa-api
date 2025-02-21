namespace MongoDb.Application.Data;

public interface IMongoConfiguration
{
        string ConnectionString {get; set;}

        string DatabaseName {get; set;}

        string ProductsCollectionName {get; set;}
        string CategoriesCollectionName {get; set;}
}