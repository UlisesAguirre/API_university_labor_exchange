﻿using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface ICareerRepository : IRepository
    {
        public Career? GetCareerBy(int careerId);
        public void AddCareer(Career newCareer);
        void UpdateCareer(Career updateCareer);
        public ICollection<Career> GetCareersForForm();
        void DeleteCareer(int careerId);
    }
}
