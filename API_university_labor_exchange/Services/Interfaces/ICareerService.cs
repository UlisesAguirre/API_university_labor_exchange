﻿using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Models.CareerDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface ICareerService
    {

        public ReadCareerDTO GetCareerById(int careerId);
        public ReadCareerDTO AddCareer(CreateCareerDTO createCareerDTO);
        public ICollection<ReadCareersForFormDTO> GetCareersForForm();
        void UpdateCareer(CreateCareerDTO createCareerDTO);
        void DeleteCareer(int careerId);
    }
}
