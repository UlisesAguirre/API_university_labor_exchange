﻿using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Models.CompanyDTOs;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile() 
        {
            CreateMap<Company, ReadAllCompanyDTO>();
            CreateMap<UpdateCompanyDTO, Company>();
            CreateMap<Company, ReadProfileCompanyDTO>();

        }
    }
}
