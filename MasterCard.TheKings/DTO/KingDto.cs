using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MasterCard.TheKings.DTO
{
    public class KingDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nm")]
        public string Name { get; set; }

        [JsonPropertyName("cty")]
        public string City { get; set; }

        [JsonPropertyName("hse")]
        public string House { get; set; }

        [JsonPropertyName("yrs")]
        public string Years { get; set; }
    }
}
