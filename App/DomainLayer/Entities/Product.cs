using DomainLayer.Common;


namespace DomainLayer.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
