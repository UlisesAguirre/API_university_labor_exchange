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

        }
    }
}
