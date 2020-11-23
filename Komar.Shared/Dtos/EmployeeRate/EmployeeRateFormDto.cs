using System.ComponentModel.DataAnnotations;

namespace Komar.Shared.Dtos.EmployeeRate
{
    public class EmployeeRateFormDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 999999.9999)]
        public decimal Rate { get; set; }
    }
}
