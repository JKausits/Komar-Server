using Komar.Shared.Dtos.EmployeeType;
using Komar.Shared.Entities;
using System.Linq;

namespace Komar.DataAccess.Extensions
{
    public static class EmployeeTypeExtensions
    {
        public static IQueryable<EmployeeTypeDto> SelectEmployeeType(this IQueryable<EmployeeType> query)
        {
            return query.Select(x => new EmployeeTypeDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
