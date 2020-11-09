using AutoMapper;
using Komar.DataAccess;
using Komar.DataAccess.Extensions;
using Komar.Shared.Dtos.Category;
using Komar.Shared.Entities;
using Komar.Shared.Exceptions;
using Komar.Shared.Interfaces.Business;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komar.Business.Implementations
{
    internal class CategoryBusiness : BusinessBase<Category>, ICategoryBusiness
    {
        public CategoryBusiness(ApplicationDbContext context, IMapper mapper) : base(context, mapper, "Category")
        {
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryFormDto dto)
        {
            try
            {
                return await AddAsync<CategoryDto>(dto);
            }
            catch (DbUpdateException ex)
            {
                HandleDuplicateNameException(ex, dto.Name);
                return null;
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await RemoveAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            return await Set.SelectCategory().OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            return await FindAsync<CategoryDto>(id);
        }

        public async Task<CategoryDto> UpdateCategoryAsync(int id, CategoryFormDto dto)
        {
            try
            {
                return await UpdateAsync<CategoryDto>(id, dto);
            }
            catch (DbUpdateException ex)
            {
                HandleDuplicateNameException(ex, dto.Name);
                return null;
            }
        }
    }
}
