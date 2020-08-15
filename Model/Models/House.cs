using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotter.Model.Models
{
    public class House
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("headOfHouse")]
        public string HouseHead { get; set; }
        
        [JsonProperty("mascot")]
        public string Mascot { get; set; }

        [JsonProperty("school")]
        public string School { get; set; }
    }
}
