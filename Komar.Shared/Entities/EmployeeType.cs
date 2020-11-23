using System.Collections.Generic;

namespace Komar.Shared.Entities
{
    public class EmployeeType : Trackable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<EmployeeRate> EmployeeRates { get; } = new List<EmployeeRate>();
    }
}
