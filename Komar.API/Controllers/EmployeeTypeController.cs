using Komar.Shared.Dtos.EmployeeRate;
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
        private readonly IEmployeeRateBusiness _employeeRateBusiness;

        public EmployeeTypeController(IEmployeeTypeBusiness employeeTypeBusiness, IEmployeeRateBusiness employeeRateBusiness)
        {
            _employeeTypeBusiness = employeeTypeBusiness;
            _employeeRateBusiness = employeeRateBusiness;
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

        #region Private
        [HttpGet("{id}/rate")]
        public async Task<IActionResult> GetEmployeeTypeRates(int id)
        {
            var rates = await _employeeRateBusiness.GetEmployeeTypeRatesAsync(id);
            return Ok(rates);
        }

        [HttpGet("rate/{id}")]
        public async Task<IActionResult> GetEmployeeRate(int id)
        {
            var rate = await _employeeRateBusiness.GetEmployeeRateAsync(id);
            return Ok(rate);
        }

        [HttpPost("{id}/rate")]
        public async Task<IActionResult> CreateEmployeeTypeRate(int id, EmployeeRateFormDto dto)
        {
            var rate = await _employeeRateBusiness.CreateEmployeeRateAsync(id, dto);
            return CreatedAtAction(nameof(GetEmployeeRate), new { rate.Id }, rate);
        }

        [HttpPut("rate/{id}")]
        public async Task<IActionResult> UpdateEmployeeRate(int id, EmployeeRateFormDto dto)
        {
            var rate = await _employeeRateBusiness.UpdateEmployeeRateAsync(id, dto);
            return Ok(rate);
        }

        [HttpDelete("rate/{id}")]
        public async Task<IActionResult> DeleteEmployeeRate(int id)
        {
            await _employeeRateBusiness.DeleteEmployeeRateAsync(id);
            return NoContent();
        }
        #endregion
    }
}
