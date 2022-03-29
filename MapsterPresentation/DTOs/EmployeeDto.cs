﻿using MapsterPresentation.Models;

namespace MapsterPresentation.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte Childs { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoleId { get; set; }
        public CarDto? Car { get; set; }
    }
}
