using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Domain.SQL.Entities
{
    public class products
    {
        public int id_product { get; set; }
        public string name { get; set; }
        public ICollection<products_categories> product_category { get; set; }
        public ICollection<products_suppliers> product_supplier { get; set; }
    }
}