using Komar.Shared.Dtos.EmployeeType;
using Komar.Shared.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Komar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeBusiness _employeeTypeBusiness;

        public EmployeeTypeController(IEmployeeTypeBusiness employeeTypeBusiness)
        {
            _employeeTypeBusiness = employeeTypeBusiness;
        }

        [HttpGet()]
        public async Task<IActionResult> GetEmployeeTypes()
        {
            var employeeTypes = await _employeeTypeBusiness.GetEmployeeTypesAsync();
            return Ok(employeeTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeType(int id)
        {
            var employeeType = await _employeeTypeBusiness.GetEmployeeTypeAsync(id);
            return Ok(employeeType);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateEmployeeType(EmployeeTypeFormDto dto)
        {
            var employeeType = await _employeeTypeBusiness.CreateEmployeeTypeAsync(dto);
            return CreatedAtAction(nameof(GetEmployeeType), new { employeeType.Id }, employeeType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeType(int id, EmployeeTypeFormDto dto)
        {
            var employeeType = await _employeeTypeBusiness.UpdateEmployeeTypeAsync(id, dto);
            return Ok(employeeType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeType(int id)
        {
            await _employeeTypeBusiness.DeleteEmployeeTypeAsync(id);
            return NoContent();
        }
    }
}
