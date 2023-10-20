using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Implementations
{
    public class CareerRepository : Repository, ICareerRepository
    {

        public CareerRepository(UniversityLaborExchangeContext context) : base(context) { }

        public IEnumerable<Career> GetAllCareers()
        {
            return _context.Careers.OrderBy(c => c.Name).ToList();
        }

        public ICollection<Career> GetCareersForForm()
        {
            return _context.Careers.Where(c => c.State == true).OrderBy(c => c.Name).ToList();
        }
        public Career? GetCareerBy(int careerId)
        {
            return _context.Careers.FirstOrDefault(c => c.IdCarrer == careerId);
        }
        public void AddCareer(Career newCareer)
        {
            _context.Careers.Add(newCareer);
        }

        public void UpdateCareer(Career updateCareer)
        {
            _context.Entry(updateCareer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCareer(int careerId)
        {
            var career = _context.Careers.Find(careerId);

            if (career != null)
            {
                career.State = false;
            }
        }
    }
}
