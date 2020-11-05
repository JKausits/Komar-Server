using Komar.Shared.Dtos.Brand;
using Komar.Shared.Dtos.Category;

namespace Komar.Shared.Dtos.Material
{
    public class MaterialDetailDto
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
        public CategoryDto Category { get; set; }
        public BrandDto Brand { get; set; }
    }
}
