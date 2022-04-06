﻿namespace MapsterPresentation.DTOs
{
    public class PersonalInfoDto
    {
        public int Id { get; set; }
        public string? CompleteName { get; set; }
        public byte Children { get; set; }
        public int Age { get; set; }
        public bool CanRetire { get; set; }
        public string CarInfo { get; set; }
    }
}
