using API_university_labor_exchange.Enums;
using System.Text.Json.Serialization;

namespace API_university_labor_exchange.Models.Company
{
    public class CreateCompanyDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Cuit { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public State State { get; set; } = State.SinAsignar;
        public string SocialReason { get; set; }
    }
}
