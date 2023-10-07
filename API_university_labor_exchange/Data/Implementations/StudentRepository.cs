using API_university_labor_exchange.Data.Interfaces;
using API_university_labor_exchange.DBContext;
using API_university_labor_exchange.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API_university_labor_exchange.Data.Implementations
{
    public class StudentRepository : Repository, IStudentRepository
    {
        public StudentRepository(UniversityLaborExchangeContext context) : base(context) { }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.Include(s=> s.StudentsSkills).ToList();
        }

        public Student? GetStudent(int id)
        {
            return _context.Students.Include(s => s.StudentsSkills)
                .FirstOrDefault(s => s.IdUser == id);
        }

        public void UpdateStudent(Student student)
        {
 
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void UpdateStudentsSkill(StudentsSkill skill, int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.IdUser == id);


            var existingSkill = student.StudentsSkills.FirstOrDefault(s => s.IdSkill == skill.IdSkill);
            
            if (existingSkill != null)
            {
                existingSkill.SkillLevel = skill.SkillLevel;
            } else
            {
                student.StudentsSkills.Add(skill);
            }

            _context.SaveChanges();

        }

        //Lo dejo por si despues el alumno puede agregar skills que no esten en la bd <--------

        //public void AddStudentsSkill(StudentsSkill skill, int id)
        //{
        //    var student = _context.Students.FirstOrDefault(s => s.IdUser == id);

        //    var newSkill = new StudentsSkill
        //    {
        //        Legajo = student.Legajo,
        //        IdSkill = skill.IdSkill,
        //        SkillLevel = skill.SkillLevel
        //    };

        //    student.StudentsSkills.Add(newSkill);

        //    _context.SaveChanges();
        //}

        public void DeleteStudentsSkill(List<StudentsSkill> skill, int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.IdUser == id);

            var skillsToDelete = student.StudentsSkills.Where(s => !skill.Any(u => u.IdSkill == s.IdSkill)).ToList();

            foreach (var removeSkill in skillsToDelete)
            {
                student.StudentsSkills.Remove(removeSkill);
            }
            

            _context.SaveChanges();
        }
    }
}
