﻿using API_university_labor_exchange.Enums;
using System.Text.Json.Serialization;

namespace API_university_labor_exchange.Models.StudentDTOs
{
    public class CreateStudentDTO
    {
        public string Legajo { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public State State { get; set; } = State.SinAsignar;
    }
}
