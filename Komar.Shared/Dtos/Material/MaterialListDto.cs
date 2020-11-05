using Komar.Shared.Dtos.Brand;
using Komar.Shared.Dtos.Category;

namespace Komar.Shared.Dtos.Material
{
    public class MaterialListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelNumber { get; set; }
        public string Size { get; set; }
        public decimal SalePrice { get; set; }
        public CategoryDto Category { get; set; }
        public BrandDto Brand { get; set; }
    }
}
