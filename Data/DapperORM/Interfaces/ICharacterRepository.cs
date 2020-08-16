using HarryPotter.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HarryPotter.Data.DapperORM.Interface
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> GetCharacters(string house = "", string patronus = "", string school = "", string role = "");

        bool InsertCharacter(string name, string role, string house, string patronus, string school);
        
        Character GetCharacterById(string id);

        bool UpdateCharacter(Character characterToUpdate);

        bool DeleteCharacter(string id);
    }
}