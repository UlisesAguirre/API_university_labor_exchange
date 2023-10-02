namespace API_university_labor_exchange.Models.Company
{
    public class CreateCompanyDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Cuit { get; set; }

        public string SocialReason { get; set; }
    }
}
