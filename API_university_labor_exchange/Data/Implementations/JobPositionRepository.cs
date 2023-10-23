using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;
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
            return _context.JobPositions.Include(j => j.JobPositionsCareers)
                .Include(j => j.JobPostionsSkills).ToList();
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
                 .Include(j => j.JobPostionsSkills)
                    .ThenInclude(js => js.IdSkillNavigation)
                .Include(j => j.JobPositionsCareers)
                    .ThenInclude(jc => jc.IdCareerNavigation)
                .Include(j => j.StudentsJobPositions)
                    .ThenInclude(sj => sj.LegajoNavigation)
                    .ThenInclude(ss => ss.IdUserNavigation)
                .ToList();
        }

        public void AddStudentJobPosition(StudentsJobPosition studentsJobPosition)
        {
            _context.StudentsJobPositions.Add(studentsJobPosition);
            _context.SaveChanges();
        }
    }
}
