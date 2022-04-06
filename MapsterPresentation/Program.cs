using Mapster;
using MapsterPresentation.DTOs;
using MapsterPresentation.Models;
using MapsterPresentation.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddAutoMapper(typeof(Program));

//Mapster custom configuration
TypeAdapterConfig<Employee, PersonalInfoDto>.NewConfig()
    .Map(dest => dest.CompleteName, src => $"{src.FirstName} {src.LastName}")

    .Map(dest => dest.Age, src => Math.Truncate((DateTime.Now - src.BirthDate).TotalDays / 365.25))

    .Map(dest => dest.CarInfo,
        src => $"{src.FirstName} is the Owner of the {src.Car.Model}",
        srcCond => srcCond.Car.IsOwner)

    .Map(dest => dest.CarInfo, 
        src => $"The {src.Car.Model} belongs to the company", 
        srcCond => !srcCond.Car.IsOwner)

    .AfterMapping(dest => dest.CanRetire = dest.Age >= 65);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
