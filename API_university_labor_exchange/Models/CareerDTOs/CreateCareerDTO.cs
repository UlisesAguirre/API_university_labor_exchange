using System.Text.Json.Serialization;

namespace API_university_labor_exchange.Models.CareerDTOs
{
    public class CreateCareerDTO
    {
        public int IdCarrer { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CareerType CareerType { get; set; }

        public int TotalSubjets { get; set; }
    }
}
