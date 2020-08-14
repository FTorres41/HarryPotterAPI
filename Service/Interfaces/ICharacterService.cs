using System.Collections.Generic;
using HarryPotter.Model;

namespace HarryPotter.Service.Interface
{
    public interface ICharacterService
    {
        IEnumerable<Character> GetCharacters(string house = "", string patronus = "", string school = "", string role = "");
        
        void InsertCharacter(string name, string role, string patronus, string school, string house);

        void UpdateCharacter(string id, string name, string role, string patronus, string school, string house);
        
        void DeleteCharacter(string id);
    }
}