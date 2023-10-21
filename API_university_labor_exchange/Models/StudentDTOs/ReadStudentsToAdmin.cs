using API_university_labor_exchange.Enums;

namespace API_university_labor_exchange.Models.StudentDTOs
{
    public class ReadStudentsToAdmin
    {
        public string Email { get; set; } = null!;
        public string Legajo { get; set; } = null;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserType { get; set; } = null!;

        public int IdUser { get; set; }

        public State? State { get; set; }
    }
}
