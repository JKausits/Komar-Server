using System.ComponentModel.DataAnnotations;

namespace Komar.Shared.Dtos.Brand
{
    public class BrandFormDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
