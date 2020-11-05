using System.ComponentModel.DataAnnotations;

namespace Komar.Shared.Dtos.Material
{
    public class MaterialFormDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string ModelNumber { get; set; }

        [MaxLength(100)]
        public string Size { get; set; }

        [Required]
        [Range(0, 999999.9999)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 999999.9999)]
        public decimal SalePrice { get; set; }

        [Required]
        [Range(0, 999999.9999)]
        public decimal Tax { get; set; }

        [Required]
        [Range(0, 999.99)]
        public decimal Markup { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }
    }
}
