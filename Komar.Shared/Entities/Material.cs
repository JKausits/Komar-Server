namespace Komar.Shared.Entities
{
    public class Material : Trackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ModelNumber { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Tax { get; set; }
        public decimal Markup { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

    }
}
