using API_university_labor_exchange.Enums;

namespace API_university_labor_exchange.Models.JobPositionDTOs
{
    public class SetJobPositionStateDTO
    {
        public int IdJobPosition { get; set; }
        public State State { get; set; }
    }
}
