﻿using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Implementations
{
    public class CareerRepository : Repository, ICareerRepository
    {

        public CareerRepository(UniversityLaborExchangeContext context) : base(context) { }

        public IEnumerable<Career> GetAllCareers()
        {
            return _context.Careers.ToList();
        }
        public Career? GetCareerBy(int careerId)
        {
            return _context.Careers.FirstOrDefault(c => c.IdCarrer == careerId);
        }
        public void AddCareer(Career newCareer)
        {
            _context.Careers.Add(newCareer);
        }
    }
}