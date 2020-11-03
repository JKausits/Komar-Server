using Komar.Shared.Dtos.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komar.Shared.Interfaces.Business
{
    public interface ICategoryBusiness
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryFormDto dto);
        Task<CategoryDto> UpdateCategoryAsync(int id, CategoryFormDto dto);
        Task DeleteCategoryAsync(int id);
    }
}
