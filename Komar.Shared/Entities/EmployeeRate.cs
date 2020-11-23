namespace Komar.Shared.Entities
{
    public class EmployeeRate : Trackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public int EmployeeTypeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
    }
}
