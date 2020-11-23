using Komar.Shared.Dtos.EmployeeRate;
using Komar.Shared.Entities;
using System.Linq;

namespace Komar.DataAccess.Extensions
{
    public static class EmployeeRateExtensions
    {

        public static IQueryable<EmployeeRate> FilterByEmployeeType(this IQueryable<EmployeeRate> query, int id)
        {
            return query.Where(x => x.EmployeeTypeId == id);
        }

        public static IQueryable<EmployeeRateDto> SelectEmployeeRate(this IQueryable<EmployeeRate> query)
        {
            return query.Select(x => new EmployeeRateDto
            {
                Id = x.Id,
                Name = x.Name,
                Rate = x.Rate,
                EmployeeTypeId = x.EmployeeTypeId
            });
        }
    }
}
