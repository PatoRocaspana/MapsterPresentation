using Mapster;
using MapsterPresentation.DTOs;
using MapsterPresentation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MapsterPresentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public PersonalInfoController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PersonalInfoDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRepository.GetAllAsync();

            if (employees == null)
                return NotFound();

            var employeesDto = employees.Adapt<List<PersonalInfoDto>>();

            return Ok(employeesDto);
        }
    }
}
