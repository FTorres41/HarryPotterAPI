using System.Collections.Generic;
using HarryPotter.Data.DapperORM.Interface;
using HarryPotter.Model;
using HarryPotter.Service.Interface;

namespace HarryPotter.Service.Class
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public void InsertCharacter(string name, string role, string patronus, string school, string house)
        {
            _characterRepository.InsertCharacter(name, role, house, patronus, school);
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
    }
}