using MapsterPresentation.DTOs;
using MapsterPresentation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MapsterPresentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeManualMapController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManualMapController(IEmployeeRepository employeeRepository)
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

            var employeesDto = employees.Select(entity => new EmployeeDto
            {
                Id = entity.Id,
                FirstName = entity?.FirstName,
                LastName = entity?.LastName,
                BirthDate = entity.BirthDate,
                Children = (byte)entity.Children,
                RoleId = entity.Role.Id,
                Car = new CarDto
                {
                    Id = entity.Car.Id,
                    Brand = entity.Car?.Brand,
                    Model = entity.Car?.Model,
                    Year = entity.Car.Year,
                    IsOwner = entity.Car.IsOwner
                }
            }).ToList();

            return Ok(employeesDto);
        }
    }
}
