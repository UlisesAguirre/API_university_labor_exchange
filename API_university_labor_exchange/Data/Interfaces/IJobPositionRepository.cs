using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.JobPositionDTOs;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface IJobPositionRepository : IRepository
    {
        public void AddJobPosition(JobPosition jobPosition);
        ICollection<JobPosition> GetAllJobPosition();
        public ICollection<JobPosition> GetCompanyJobPositions(string idCompany);

        public ICollection<JobPosition> GetJobPositions();
        void SetJobPositionState(SetJobPositionStateDTO jobPosition);

        public void AddStudentJobPosition(StudentsJobPosition studentsJobPosition);

    }
}
