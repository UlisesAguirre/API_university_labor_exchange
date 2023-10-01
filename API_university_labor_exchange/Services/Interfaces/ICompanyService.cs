using API_university_labor_exchange.Models.Company;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface ICompanyService
    {
        public IEnumerable<ReadAllCompanyDTO> GetAllCompanies();
        public ReadAllCompanyDTO? GetCompany(int id);
        public void UpdateCompany(UpdateCompanyDTO company, int id);
    }
}
