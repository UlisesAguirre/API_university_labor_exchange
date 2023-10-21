using API_university_labor_exchange.Enums;

namespace API_university_labor_exchange.Models.CompanyDTOs
{
    public class ReadCompaniesToAdmin
    {
        public string Email { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public string SocialReason { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserType { get; set; } = null!;

        public int IdUser { get; set; }

        public State? State { get; set; }
    }
}
