using Komar.Shared.Dtos.Category;
using Komar.Shared.Entities;
using System.Linq;

namespace Komar.DataAccess.Extensions
{
    public static class CategoryExtensions
    {
        public static IQueryable<CategoryDto> SelectCategory(this IQueryable<Category> query)
        {
            return query.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
