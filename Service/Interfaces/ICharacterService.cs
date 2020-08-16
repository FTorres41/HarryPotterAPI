using System.Collections.Generic;
using System.Threading.Tasks;
using HarryPotter.Domain.Enums;
using HarryPotter.Model;

namespace HarryPotter.Service.Interface
{
    public interface ICharacterService
    {
        IEnumerable<Character> GetCharacters(string house = "", string patronus = "", string school = "", string role = "");

        Task<bool> InsertCharacter(string name, string role, string patronus, EHouse? house);

        Task<bool> UpdateCharacter(string id, string name, string role, string patronus, EHouse? house);
        
        bool DeleteCharacter(string id);
    }
}