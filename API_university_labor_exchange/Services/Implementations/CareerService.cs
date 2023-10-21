using API_university_labor_exchange.Data.Implementations;
using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.CareerDTOs;
using API_university_labor_exchange.Services.Interfaces;
using AutoMapper;

namespace API_university_labor_exchange.Services.Implementations
{
    public class CareerService : ICareerService
    {
        private readonly ICareerRepository _careerRepository;
        private readonly IMapper _mapper;
        public CareerService(ICareerRepository careerRepository, IMapper mapper) 
        {
            _careerRepository = careerRepository;
            _mapper = mapper;
        }

        public ICollection<ReadCareerDTO> GetAllCareers()
        {
           var careers = _careerRepository.GetAllCareers();
            return _mapper.Map<ICollection<ReadCareerDTO>>(careers);
        }

        public ICollection<ReadCareersForFormDTO> GetCareersForForm()
        {
            var careers = _careerRepository.GetCareersForForm();
            return _mapper.Map<ICollection<ReadCareersForFormDTO>>(careers);

        }

        public ReadCareerDTO GetCareerById(int careerId)
        {
            var career = _careerRepository.GetCareerBy(careerId);
            return _mapper.Map<ReadCareerDTO>(career);
        }
        public ReadCareerDTO AddCareer(CreateCareerDTO createCareerDTO)
        {
            Career newCareer = new Career
            {
                Name = createCareerDTO.Name,
                Abbreviation = createCareerDTO.Abbreviation,
                CareerType = createCareerDTO.CareerType,
                TotalSubjets = createCareerDTO.TotalSubjets,
                State = true
            };

            _careerRepository.AddCareer(newCareer);
            if (_careerRepository.SaveChanges()){
                return _mapper.Map<ReadCareerDTO>(newCareer);
            }
            return null;
        }

        public void UpdateCareer(CreateCareerDTO createCareerDTO)
        {
            var updateCareer = _mapper.Map<Career>(createCareerDTO);
            _careerRepository.UpdateCareer(updateCareer);

        }

        public void DeleteCareer(int careerId)
        {
            if (careerId != null)
            {
                _careerRepository.DeleteCareer(careerId);
                _careerRepository.SaveChanges();
            }
        }
    }
}
