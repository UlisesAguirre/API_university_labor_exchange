namespace API_university_labor_exchange.Models.CompanyDTOs
{
    public class ReadProfileCompanyDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }

        public string CompanyName { get; set; }
        public string Cuit { get; set; }

        public string SocialReason { get; set; }

        public string? Sector { get; set; }

        public string? Web { get; set; }
        public string? TelephoneNumber { get; set; }
    }
}
