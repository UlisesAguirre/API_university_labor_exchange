using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface ICareerRepository : IRepository
    {
        public IEnumerable<Career> GetAllCareers();
        public Career? GetCareerBy(int careerId);
        public void AddCareer(Career newCareer);

        public ICollection<Career> GetCareersForForm();

        //public void UpdateCareer(Career careerToUpdate);
        //public void DeleteCareer(int careerId);

    }
}
