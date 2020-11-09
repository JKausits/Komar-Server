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
            var brands = await _brandBusiness.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _brandBusiness.GetBrandAsync(id);
            return Ok(brand);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBrand(BrandFormDto dto)
        {
            var brand = await _brandBusiness.CreateBrandAsync(dto);
            return CreatedAtAction(nameof(GetBrand), new { brand.Id }, brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, BrandFormDto dto)
        {
            var brand = await _brandBusiness.UpdateBrandAsync(id, dto);
            return Ok(brand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandBusiness.DeleteBrandAsync(id);
            return NoContent();
        }
    }
}
