﻿namespace MapsterPresentation.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Childs { get; set; }
        public DateTime BirthDate { get; set; }
        public Role? Role { get; set; }
        public Car? Car { get; set; }
    }
}
