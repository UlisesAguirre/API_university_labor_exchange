using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models;
using API_university_labor_exchange.Models.JobPositionDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Data;

namespace API_university_labor_exchange.Data.Implementations
{
    public class JobPositionRepository : Repository, IJobPositionRepository
    {
        public JobPositionRepository(UniversityLaborExchangeContext context) : base(context) { }

        public void AddJobPosition(JobPosition jobPosition)
        {
            _context.JobPositions.Add(jobPosition);
            _context.SaveChanges();
        }

        public ICollection<JobPosition> GetAllJobPosition()
        {
            return _context.JobPositions
                .Include(j => j.JobPositionsCareers)
                .Include(j => j.JobPostionsSkills)
                .OrderByDescending(j => j.State)
                .ToList();
        }

        public ICollection<JobPosition> GetCompanyJobPositions(string idCompany)
        {
            //return _context.JobPositions
            //    .Where(j => j.IdCompany == idCompany)
            //    .Include(j => j.JobPostionsSkills)
            //    .Include(j => j.JobPositionsCareers)
            //    .Include(j => j.StudentsJobPositions)
            //    .ToList();     

            return _context.JobPositions
                .Where(j => j.IdCompany == idCompany)
                .Include(j => j.JobPostionsSkills)
                    .ThenInclude(js => js.IdSkillNavigation)
                .Include(j => j.JobPositionsCareers)
                    .ThenInclude(jc => jc.IdCareerNavigation)
                .Include(j => j.StudentsJobPositions)
                    .ThenInclude(sj => sj.LegajoNavigation)
                    .ThenInclude(ss => ss.IdUserNavigation)
                .ToList();
        }

        public ICollection<JobPosition> GetJobPositions()
        {
            return _context.JobPositions
                .Where(jp => jp.State == Enums.State.Habilitado || (jp.JobType == "Trabajo" && jp.State != Enums.State.Deshabilitado))
                .Include(jp => jp.JobPositionsCareers)
                .Include(jp => jp.JobPostionsSkills)
                .ToList();
        }

        public void SetJobPositionState(SetJobPositionStateDTO jobPosition)
        {
            var findedJobPosition = _context.JobPositions.FirstOrDefault(j => j.IdJobPosition == jobPosition.IdJobPosition);

            if (findedJobPosition != null)
            {
                findedJobPosition.State = jobPosition.State;
            }

            _context.SaveChanges();

        }
    }
}
