using System.ComponentModel.DataAnnotations;

namespace Komar.Shared.Dtos.Category
{
    public class CategoryFormDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
