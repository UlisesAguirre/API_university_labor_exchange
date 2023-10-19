using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Models.CareerDTOs;

namespace API_university_labor_exchange.Services.Interfaces
{
    public interface ICareerService
    {
        public ICollection<ReadCareerDTO> GetAllCareers();
        public ReadCareerDTO GetCareerById (int careerId);
        public ReadCareerDTO AddCareer(CreateCareerDTO createCareerDTO);

        public ICollection<ReadCareersForFormDTO> GetCareersForForm();

        //public void UpdateCareer(UpdateCareerDTO updateCareerDTO);
        //public void DeleteCareer(int careerId);
    }
}
