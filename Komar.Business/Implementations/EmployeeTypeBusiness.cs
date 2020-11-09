using AutoMapper;
using Komar.DataAccess;
using Komar.DataAccess.Extensions;
using Komar.Shared.Dtos.EmployeeType;
using Komar.Shared.Entities;
using Komar.Shared.Interfaces.Business;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komar.Business.Implementations
{
    internal class EmployeeTypeBusiness : BusinessBase<EmployeeType>, IEmployeeTypeBusiness
    {
        public EmployeeTypeBusiness(ApplicationDbContext context, IMapper mapper) : base(context, mapper, "Employee Type")
        {
        }

        public async Task<EmployeeTypeDto> CreateEmployeeTypeAsync(EmployeeTypeFormDto dto)
        {
            try
            {
                return await AddAsync<EmployeeTypeDto>(dto);
            }
            catch (DbUpdateException ex)
            {
                HandleDuplicateNameException(ex, dto.Name);
                return null;
            }
        }

        public async Task DeleteEmployeeTypeAsync(int id)
        {
            await RemoveAsync(id);
        }

        public async Task<IEnumerable<EmployeeTypeDto>> GetEmployeeTypesAsync()
        {
            return await Set.SelectEmployeeType().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<EmployeeTypeDto> GetEmployeeTypeAsync(int id)
        {
            return await FindAsync<EmployeeTypeDto>(id);
        }

        public async Task<EmployeeTypeDto> UpdateEmployeeTypeAsync(int id, EmployeeTypeFormDto dto)
        {
            try
            {
                return await UpdateAsync<EmployeeTypeDto>(id, dto);
            }
            catch (DbUpdateException ex)
            {
                HandleDuplicateNameException(ex, dto.Name);
                return null;
            }
        }
    }
}
