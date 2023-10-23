using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Implementations
{
    public class CompanyRepository: Repository, ICompanyRepository
    {
        public CompanyRepository(UniversityLaborExchangeContext context) : base(context) { }

        public IEnumerable<Company> GetAllCompanies() 
        {
            return _context.Companies.ToList();
        }


        public Company? GetCompany(int id) 
        {
            return _context.Companies.FirstOrDefault(c => c.IdUser == id);
        }
        public void UpdateCompany(Company company)
        {
            _context.Entry(company).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_context.Companies.Update(company);

        }

        public Company? GetCompanyByCUIT(string cuit)
        {
            return _context.Companies.FirstOrDefault(c => c.Cuit == cuit);
        }
        
    }
}
