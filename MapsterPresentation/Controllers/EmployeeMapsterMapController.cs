using Mapster;
using MapsterPresentation.DTOs;
using MapsterPresentation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MapsterPresentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeMapsterMapController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeMapsterMapController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRepository.GetAllAsync();

            if (employees == null)
                return NotFound();

            var employeesDto = employees.Adapt<List<EmployeeDto>>();

            return Ok(employeesDto);
        }
    }
}
