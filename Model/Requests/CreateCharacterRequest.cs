using Flunt.Notifications;
using Flunt.Validations;
using HarryPotter.Domain.Enums;
using HarryPotter.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotter.Model.Requests
{
    public class CreateCharacterRequest : Request
    {
        public string Name { get; set; } 
        public string Role { get; set; } 
        public string Patronus { get; set; } 
        public EHouse House { get; set; }

        public new void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Nome", "É obrigatorio informar um valor para o Nome"));
        }
    }
}
