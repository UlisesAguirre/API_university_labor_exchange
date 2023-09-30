using System.ComponentModel.DataAnnotations;

namespace API_university_labor_exchange.Entities
{
    public class Credentials
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
