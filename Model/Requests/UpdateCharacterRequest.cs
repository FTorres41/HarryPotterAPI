using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotter.Model.Requests
{
    public class UpdateCharacterRequest
    {
        public string Id { get; set; }
        public string Name { get; set; } 
        public string Role { get; set; } 
        public string Patronus { get; set; } 
        public string School { get; set; } 
        public string House { get; set; }
    }
}
