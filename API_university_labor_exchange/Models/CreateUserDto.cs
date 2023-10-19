using API_university_labor_exchange.Enums;
using System.Text.Json.Serialization;

namespace API_university_labor_exchange.Entities
{
    public class CreateUserDto
    {
        public string Email { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string UserType { get; set; } = null!;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public State State { get; set; } = State.SinAsignar;

        public int IdUser { get; set; }
    }
}
