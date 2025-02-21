namespace MongoDB.Domain.SQL.Entities
{
    public class products_suppliers
    {
        public int product_id { get; set; }
        public int supplier_id { get; set; }
        public virtual suppliers supplier { get; set; }
        public virtual products product {get; set;}
    }
}