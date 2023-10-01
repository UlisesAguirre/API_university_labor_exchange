
using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Services.Interfaces;
using AutoMapper;

namespace API_university_labor_exchange.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public IEnumerable<ReadAllCompanyDTO> GetAllCompanies()
        { 
            var companies = _companyRepository.GetAllCompanies();
            return _mapper.Map<IEnumerable<ReadAllCompanyDTO>>(companies);
        }
        public ReadAllCompanyDTO? GetCompany(int id) 
        {
            var company = _companyRepository.GetCompany(id);
            return _mapper.Map<ReadAllCompanyDTO>(company);
        }

        public void UpdateCompany(UpdateCompanyDTO company, int id)
        {
            var CompanyToUpdate = _companyRepository.GetCompany(id);
            _mapper.Map(company, CompanyToUpdate);
            _companyRepository.UpdateCompany(CompanyToUpdate);
            _companyRepository.SaveChanges();

        }
    }
}
