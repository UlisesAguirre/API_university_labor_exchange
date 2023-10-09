
using API_university_labor_exchange.Data.Implementations;
using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Company;
using API_university_labor_exchange.Models.CompanyDTOs;
using API_university_labor_exchange.Models.StudentDTOs;
using API_university_labor_exchange.Services.Interfaces;
using AutoMapper;

namespace API_university_labor_exchange.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CompanyService(ICompanyRepository companyRepository, IUserRepository userRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
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
            User userData = _userRepository.GetUserById(id);

            var userCompany = _mapper.Map<ReadAllCompanyDTO>(company);

            userCompany.Email = userData.Email;
            userCompany.Username = userData.Username;

            return userCompany;
        }

        public void UpdateCompany(UpdateCompanyDTO company, int id)
        {
            var CompanyToUpdate = _companyRepository.GetCompany(id);
            User? userToUpdate = _userRepository.GetUserById(id);

            if (CompanyToUpdate != null && userToUpdate != null) 
            { 
                userToUpdate.Email = company.Email;
                userToUpdate.Username = company.Username;

                _mapper.Map(company, CompanyToUpdate);
                _companyRepository.UpdateCompany(CompanyToUpdate);
                _userRepository.UpdateUser(userToUpdate);

                _companyRepository.SaveChanges(); 
            }
           
        }

        public ReadProfileCompanyDTO GetProfile(int id)
        {
            User userData = _userRepository.GetUserById(id);
            Company companyData = _companyRepository.GetCompany(id);

            ReadProfileCompanyDTO companyProfile = _mapper.Map<ReadProfileCompanyDTO>(companyData);

            companyProfile.Email = userData.Email;
            companyProfile.Username = userData.Username;

            return companyProfile;

        }
    }
}
