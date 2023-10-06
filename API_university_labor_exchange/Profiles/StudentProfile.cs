using API_university_labor_exchange.Entities;
using API_university_labor_exchange.Models.Student;
using API_university_labor_exchange.Models.StudentDTOs;
using AutoMapper;

namespace API_university_labor_exchange.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() 
        {
            CreateMap<Student, ReadAllStudentDTO>();
            CreateMap<Student, ReadProfileStudentDTO>();
            CreateMap<UpdateStudentDTO, Student>();

            //CreateMap<UpdateStudentDTO, Student>()
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //.ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType))
            //.ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.DocumentNumber))
            //.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            //.ForMember(dest => dest.CivilStatus, opt => opt.MapFrom(src => src.CivilStatus))
            //.ForMember(dest => dest.Cuil, opt => opt.MapFrom(src => src.Cuil))
            //.ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex))
            //.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            //.ForMember(dest => dest.AddressNumber, opt => opt.MapFrom(src => src.AddressNumber))
            //.ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Floor))
            //.ForMember(dest => dest.Flat, opt => opt.MapFrom(src => src.Flat))
            //.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            //.ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Province))
            //.ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            //.ForMember(dest => dest.Curriculum, opt => opt.MapFrom(src => src.Curriculum))
            //.ForMember(dest => dest.GithubProfileUrl, opt => opt.MapFrom(src => src.GithubProfileUrl))
            //.ForMember(dest => dest.LinkedInProfileUrl, opt => opt.MapFrom(src => src.LinkedInProfileUrl))
            //.ForMember(dest => dest.TelephoneNumber, opt => opt.MapFrom(src => src.TelephoneNumber))
            //.ForMember(dest => dest.ApprovedSubjects, opt => opt.MapFrom(src => src.ApprovedSubjects))
            //.ForMember(dest => dest.StudyProgram, opt => opt.MapFrom(src => src.StudyProgram))
            //.ForMember(dest => dest.CurrentCareerYear, opt => opt.MapFrom(src => src.CurrentCareerYear))
            //.ForMember(dest => dest.Turn, opt => opt.MapFrom(src => src.Turn))
            //.ForMember(dest => dest.Average, opt => opt.MapFrom(src => src.Average))
            //.ForMember(dest => dest.AverageWithFails, opt => opt.MapFrom(src => src.AverageWithFails))
            //.ForMember(dest => dest.SecondaryDegree, opt => opt.MapFrom(src => src.SecondaryDegree))
            //.ForMember(dest => dest.Observations, opt => opt.MapFrom(src => src.Observations))
            //.ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.IdUser))
            //.ForMember(dest => dest.IdCarrer, opt => opt.MapFrom(src => src.IdCarrer))
            //.ForMember(dest => dest.StudentsSkills, opt => opt.MapFrom(src => src.StudentsSkills));



            //CreateMap<UpdateStudentDTO, User>()
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.userName));

        }
    }
}
