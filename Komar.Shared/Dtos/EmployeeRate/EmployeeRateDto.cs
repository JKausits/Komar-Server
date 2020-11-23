namespace Komar.Shared.Dtos.EmployeeRate
{
    public class EmployeeRateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public int EmployeeTypeId { get; set; }
    }
}
