using Newtonsoft.Json;

namespace MasterCard.TheKings.DTO
{
    public class MonarchsDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nm")]
        public string Name { get; set; }

        [JsonProperty("cty")]
        public string City { get; set; }

        [JsonProperty("hse")]
        public string House { get; set; }

        [JsonProperty("yrs")]
        public string Period { get; set; }
    }
}
