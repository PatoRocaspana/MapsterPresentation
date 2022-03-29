using Mapster;
using MapsterPresentation.DTOs;
using MapsterPresentation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MapsterPresentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeAutoMapperMapController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AutoMapper.IMapper _autoMapper;

        public EmployeeAutoMapperMapController(IEmployeeRepository employeeRepository, AutoMapper.IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _autoMapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRepository.GetAllAsync();

            if (employees == null)
                return NotFound();

            var employeesDto = _autoMapper.Map<List<EmployeeDto>>(employees);

            return Ok(employeesDto);
        }
    }
}
