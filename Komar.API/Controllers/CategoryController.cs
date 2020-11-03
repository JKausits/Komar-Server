using Komar.Shared.Dtos.Category;
using Komar.Shared.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Komar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryBusiness _categoryBusiness;

        public CategoryController(ICategoryBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryBusiness.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryBusiness.GetCategoryAsync(id);
            return Ok(category);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCategory(CategoryFormDto dto)
        {
            var category = await _categoryBusiness.CreateCategoryAsync(dto);
            return CreatedAtAction(nameof(GetCategory), new { category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryFormDto dto)
        {
            var category = await _categoryBusiness.UpdateCategoryAsync(id, dto);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryBusiness.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
