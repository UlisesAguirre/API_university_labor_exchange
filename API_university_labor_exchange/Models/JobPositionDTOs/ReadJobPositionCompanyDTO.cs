﻿using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Enums;
using API_university_labor_exchange.Models.JobPositionDTOs.SkillsCareerListDto;
using API_university_labor_exchange.Models.Student;

namespace API_university_labor_exchange.Models.JobPositionDTOs
{
    public class ReadJobPositionCompanyDTO
    {
        public int IdJobPosition { get; set; }

        public string? JobTitle { get; set; }

        public string? JobDescription { get; set; }

        public string? BenefitsOfferedDetail { get; set; }

        public string? Location { get; set; }

        public string? PositionToCover { get; set; }

        public string? JobType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? StartDate { get; set; }

        public int? NumberOfPositionsToCover { get; set; }

        public string? WorkDay { get; set; }

        public int? InternshipDuration { get; set; }

        public DateTime? TentativeStartDate { get; set; }

        public string IdCompany { get; set; } = null!;

        public State State { get; set; }

        public List<CareersListDTO> JobPositionsCareers { get; set; } = new List<CareersListDTO>();

        public List<SkillsListDTO> JobPostionsSkills { get; set; } = new List<SkillsListDTO>();

        public List<StudentsJobPositionDTO> StudentsJobPositions { get; set; } = new List<StudentsJobPositionDTO>();
    }
}
