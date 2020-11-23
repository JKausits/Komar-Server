using Komar.Shared.Dtos.EmployeeRate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komar.Shared.Interfaces.Business
{
    public interface IEmployeeRateBusiness
    {
        Task<IEnumerable<EmployeeRateDto>> GetEmployeeTypeRatesAsync(int employeeTypeId);
        Task<EmployeeRateDto> GetEmployeeRateAsync(int id);
        Task<EmployeeRateDto> CreateEmployeeRateAsync(int id, EmployeeRateFormDto dto);
        Task<EmployeeRateDto> UpdateEmployeeRateAsync(int id, EmployeeRateFormDto dto);
        Task DeleteEmployeeRateAsync(int id);
    }
}
