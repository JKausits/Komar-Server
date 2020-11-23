using AutoMapper;
using Komar.DataAccess;
using Komar.DataAccess.Extensions;
using Komar.Shared.Dtos.EmployeeRate;
using Komar.Shared.Entities;
using Komar.Shared.Interfaces.Business;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komar.Business.Implementations
{
    internal class EmployeeRateBusiness : BusinessBase<EmployeeRate>, IEmployeeRateBusiness
    {
        public EmployeeRateBusiness(ApplicationDbContext context, IMapper mapper) : base(context, mapper, "Employee Rate")
        {
        }

        public async Task<EmployeeRateDto> CreateEmployeeRateAsync(int id, EmployeeRateFormDto dto)
        {
            try
            {
                var rate = Mapper.Map<EmployeeRate>(dto);
                rate.EmployeeTypeId = id;
                await AddAsync(rate);
                return Mapper.Map<EmployeeRateDto>(rate);
            }
            catch (DbUpdateException ex)
            {
                HandleDuplicateNameException(ex, dto.Name);
                return null;
            }
        }

        public async Task DeleteEmployeeRateAsync(int id)
        {
            await RemoveAsync(id);
        }

        public async Task<EmployeeRateDto> GetEmployeeRateAsync(int id)
        {
           return await FindAsync<EmployeeRateDto>(id);
        }

        public async Task<IEnumerable<EmployeeRateDto>> GetEmployeeTypeRatesAsync(int employeeTypeId)
        {
            return await Set.FilterByEmployeeType(employeeTypeId).SelectEmployeeRate().ToListAsync();
        }

        public async Task<EmployeeRateDto> UpdateEmployeeRateAsync(int id, EmployeeRateFormDto dto)
        {
            try
            {
                return await UpdateAsync<EmployeeRateDto>(id, dto);
            }
            catch (DbUpdateException ex)
            {
                HandleDuplicateNameException(ex, dto.Name);
                return null;
            }
        }
    }
}
