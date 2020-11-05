using Komar.Shared.Dtos.Brand;
using Komar.Shared.Dtos.Category;
using Komar.Shared.Dtos.Material;
using Komar.Shared.Entities;
using System.Linq;

namespace Komar.DataAccess.Extensions
{
    public static class MaterialExtensions
    {

        public static IQueryable<MaterialListDto> SelectMaterialList(this IQueryable<Material> query)
        {
            return query.Select(x => new MaterialListDto
            {
                Id = x.Id,
                Name = x.Name,
                SalePrice = x.SalePrice,
                Size = x.Size,
                ModelNumber = x.ModelNumber,
                Category = new CategoryDto
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name
                },
                Brand = new BrandDto
                {
                    Id = x.Brand.Id,
                    Name = x.Brand.Name
                }
            });
        }

        public static IQueryable<MaterialDetailDto> SelectMaterialDetail(this IQueryable<Material> query)
        {
            return query.Select(x => new MaterialDetailDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Size = x.Size,
                ModelNumber = x.ModelNumber,
                SalePrice = x.SalePrice,
                Tax = x.Tax,
                Price = x.Price,
                Markup = x.Markup,
                Category = new CategoryDto
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name
                },
                Brand = new BrandDto
                {
                    Id = x.Brand.Id,
                    Name = x.Brand.Name
                }
            });
        }

        public static IQueryable<Material> FilterByCategory(this IQueryable<Material> query, int? id)
        {
            if (!id.HasValue)
                return query;


            return query.Where(x => x.CategoryId == id.Value);
        }


        public static IQueryable<Material> FilterByBrand(this IQueryable<Material> query, int? id)
        {
            if (!id.HasValue)
                return query;


            return query.Where(x => x.BrandId == id.Value);
        }

        public static IQueryable<Material> FilterByTerm(this IQueryable<Material> query, string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return query;

            return query.Where(x => x.Name.Contains(term) || x.Description.Contains(term));
        }
    }
}
