namespace MongoDB.Domain.SQL.Entities
{
    public class products_categories
    {
        public int product_id { get; set; }
        public int category_id { get; set; }

        public virtual categories category {get; set;}
        public virtual products product {get; set;}
    }
}