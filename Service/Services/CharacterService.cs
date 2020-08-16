using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using HarryPotter.Data.DapperORM.Interface;
using HarryPotter.Domain.Enums;
using HarryPotter.Model;
using HarryPotter.Model.Models;
using HarryPotter.Service.Interface;
using HarryPotter.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Refit;

namespace HarryPotter.Service.Class
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService()
        {

        }

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<bool> InsertCharacter(string name, string role, string patronus, EHouse? house = null)
        {
            var houseId = string.Empty;
            var school = string.Empty;

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Favor informar um nome válido");
            
            if (house != null)
            {
                IList<House> houses = await GetHousesFromAPI();

                if (houses.Count > 0)
                {
                    foreach (var h in houses)
                    {
                        if (h.Name.Equals(house.ToString()))
                        {
                            houseId = h.Id;
                            school = h.School;
                            break;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Problema na comunicação com API externa");
                }
            }

            return _characterRepository.InsertCharacter(name, role, houseId, patronus, school);
        }


        public IEnumerable<Character> GetCharacters(string house = "", string patronus = "", string school = "", string role = "")
        {
            return _characterRepository.GetCharacters(house, patronus, school, role);
        }

        public async Task<bool> UpdateCharacter(string id, string name, string role, string patronus, EHouse? house)
        {
            var characterToUpdate = _characterRepository.GetCharacterById(id);

            if (characterToUpdate != null)
            {
                if (house != null)
                {
                    IList<House> houses = await GetHousesFromAPI();

                    if (houses.Count > 0)
                    {
                        foreach (var h in houses)
                        {
                            if (h.Name.Equals(house.ToString()))
                            {
                                characterToUpdate.House = h.Id;
                                characterToUpdate.School = h.School;
                                break;
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Problema na comunicação com API externa");
                    }
                }

                if (string.IsNullOrEmpty(name))
                    throw new ArgumentNullException("Favor informar um nome válido");

                characterToUpdate.Name = name;
                characterToUpdate.Role = role;
                characterToUpdate.Patronus = patronus;
            }
            else
            {
                throw new ArgumentNullException("Personagem não encontrado!");
            }

            return _characterRepository.UpdateCharacter(characterToUpdate);
        }

        public bool DeleteCharacter(string id)
        {
            if (id == null || id.Length == 0)
                throw new ArgumentNullException("Favor informar um Id válido!");

            return _characterRepository.DeleteCharacter(id);
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

        private string GetPotterAPIKey()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            return config["Logging:AppSettings:PotterAPI_Key"];
        }

        private async Task<IList<House>> GetHousesFromAPI()
        {
            var _potterApiClient = RestService.For<IPotterAPI>(GetPotterAPIUrl());

            return await _potterApiClient.GetHouses(GetPotterAPIKey());
        }

        #endregion
    }
}