using API_university_labor_exchange.Enums;

namespace API_university_labor_exchange.Models
{
    public class SetUserStateDTO
    {
        public int IdUser { get; set; }
        public State? State { get; set; }
    }
}
