using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterCard.Kings.DTO
{
    public class KingDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string House { get; set; }

        public int Years { get; set; }
    }
}
