using API_university_labor_exchange.Entities;

namespace API_university_labor_exchange.Data.Interfaces
{
    public interface ICompanyRepository : IRepository
    {
        public IEnumerable<Company> GetAllCompanies();
        public Company? GetCompany(int id);
        public void UpdateCompany(Company company);
    }
}
