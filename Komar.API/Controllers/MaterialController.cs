using Komar.Shared.Dtos.Material;
using Komar.Shared.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Komar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialBusiness _materialBusiness;

        public MaterialController(IMaterialBusiness materialBusiness)
        {
            _materialBusiness = materialBusiness;
        }

        [HttpGet()]
        public async Task<IActionResult> GetMaterials(int page, int pageSize, int? categoryId, int? brandId, string term)
        {
            var result = await _materialBusiness.GetMaterialsAsync(page, pageSize, categoryId, brandId, term);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterial(int id)
        {
            var material = await _materialBusiness.GetMaterialAsync(id);
            return Ok(material);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateMaterial(MaterialFormDto dto)
        {
            var material = await _materialBusiness.CreateMaterialAsync(dto);
            return CreatedAtAction(nameof(GetMaterial), new { material.Id }, material);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterial(int id, MaterialFormDto dto)
        {
            var material = await _materialBusiness.UpdateMaterialAsync(id, dto);
            return Ok(material);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            await _materialBusiness.DeleteMaterialAsync(id);
            return NoContent();
        }
    }
}
