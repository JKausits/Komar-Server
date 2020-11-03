using Komar.Shared.Dtos.Brand;
using Komar.Shared.Entities;
using System.Linq;

namespace Komar.DataAccess.Extensions
{
    public static class BrandExtensions
    {
        public static IQueryable<BrandDto> SelectBrand(this IQueryable<Brand> query)
        {
            return query.Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
