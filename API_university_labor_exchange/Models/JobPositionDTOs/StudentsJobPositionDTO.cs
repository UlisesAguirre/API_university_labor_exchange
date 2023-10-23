namespace API_university_labor_exchange.Models.JobPositionDTOs
{
    public class StudentsJobPositionDTO
    {
        public int IdJobPosition { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
