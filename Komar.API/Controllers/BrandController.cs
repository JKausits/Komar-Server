using Komar.Shared.Dtos.Brand;
using Komar.Shared.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Komar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandBusiness _brandBusiness;

        public BrandController(IBrandBusiness BrandBusiness)
        {
            _brandBusiness = BrandBusiness;
        }

        [HttpGet()]
        public async Task<IActionResult> GetBrands()
        {
            var categories = await _brandBusiness.GetBrandsAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var Brand = await _brandBusiness.GetBrandAsync(id);
            return Ok(Brand);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBrand(BrandFormDto dto)
        {
            var Brand = await _brandBusiness.CreateBrandAsync(dto);
            return CreatedAtAction(nameof(GetBrand), new { Brand.Id }, Brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, BrandFormDto dto)
        {
            var Brand = await _brandBusiness.UpdateBrandAsync(id, dto);
            return Ok(Brand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandBusiness.DeleteBrandAsync(id);
            return NoContent();
        }
    }
}
