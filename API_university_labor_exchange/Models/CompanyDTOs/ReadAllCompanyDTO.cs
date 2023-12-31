﻿using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Enums;
using System.Text.Json.Serialization;

namespace API_university_labor_exchange.Models.Company
{
    public class ReadAllCompanyDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }

        public string? CompanyName { get; set; }
        public string Cuit { get; set; } = null!;

        public string SocialReason { get; set; } = null!;

        public string? TelephoneNumber { get; set; }

        public string? Sector { get; set; }

        public string? LegalAddress { get; set; }

        public string? PostalCode { get; set; }

        public string? Web { get; set; }

        public string? Location { get; set; }
        public string? RecruiterName { get; set; }

        public string? RecruiterLastName { get; set; }

        public string? RecruiterPosition { get; set; }

        public string? RecruiterPhoneNumber { get; set; } 

        public string? RecruiterEmail { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public State State { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RecruiterRelWithCompany? RecruiterRelWithCompany { get; set; }

        public int IdUser { get; set; }

    }
}
