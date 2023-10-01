using System.Text.Json.Serialization;

namespace API_university_labor_exchange.Models.CareerDTOs
{
    public class CreateCareerDTO
    {
     
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CareerType CareerType { get; set; }

        public int TotalSubjets { get; set; }

        public string StudyProgram { get; set; }
    }
}
