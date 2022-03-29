using AutoMapper;
using MapsterPresentation.DTOs;
using MapsterPresentation.Models;

namespace MapsterPresentation.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
