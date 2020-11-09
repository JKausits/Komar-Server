using System.ComponentModel.DataAnnotations;

namespace Komar.Shared.Dtos.EmployeeType
{
    public class EmployeeTypeFormDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
