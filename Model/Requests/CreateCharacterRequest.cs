using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotter.Model.Requests
{
    public class CreateCharacterRequest
    {
        public string Name { get; set; } 
        public string Role { get; set; } 
        public string Patronus { get; set; } 
        public string School { get; set; } 
        public string House { get; set; }
    }
}
