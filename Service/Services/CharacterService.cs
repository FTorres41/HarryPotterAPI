using System.Collections.Generic;
using System.Configuration;
using System.IO;
using HarryPotter.Data.DapperORM.Interface;
using HarryPotter.Domain.Enums;
using HarryPotter.Model;
using HarryPotter.Service.Interface;
using HarryPotter.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Refit;

namespace HarryPotter.Service.Class
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public void InsertCharacter(string name, string role, string patronus, EHouse? house = null)
        {
            var houseId = string.Empty;
            var school = string.Empty;
            
            if (house != null)
            {
                var _potterApiClient = RestService.For<IPotterAPI>(GetPotterAPIUrl());
                var houses = _potterApiClient.GetHouses();

                if (houses.Count > 0)
                {
                    
                }
            }

            _characterRepository.InsertCharacter(name, role, houseId, patronus, school);
        }

        public IEnumerable<Character> GetCharacters(string house = "", string patronus = "", string school = "", string role = "")
        {
            return _characterRepository.GetCharacters(house, patronus, school, role);
        }

        public void UpdateCharacter(string id, string name, string role, string patronus, string school, string house)
        {
            
        }

        public void DeleteCharacter(string id)
        {
            
        }

        #region PRIVATE

        private string GetPotterAPIUrl()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            return config["Logging:AppSettings:PotterAPI_BaseURL"];
        }

        #endregion
    }
}