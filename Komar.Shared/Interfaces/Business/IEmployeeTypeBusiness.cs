using Komar.Shared.Dtos.EmployeeType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komar.Shared.Interfaces.Business
{
    public interface IEmployeeTypeBusiness
    {
        Task<IEnumerable<EmployeeTypeDto>> GetEmployeeTypesAsync();
        Task<EmployeeTypeDto> GetEmployeeTypeAsync(int id);
        Task<EmployeeTypeDto> CreateEmployeeTypeAsync(EmployeeTypeFormDto dto);
        Task<EmployeeTypeDto> UpdateEmployeeTypeAsync(int id, EmployeeTypeFormDto dto);
        Task DeleteEmployeeTypeAsync(int id);
    }
}
