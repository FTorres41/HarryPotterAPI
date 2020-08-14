using HarryPotter.Model;
using System.Collections.Generic;

namespace HarryPotter.Data.DapperORM.Interface
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> GetCharacters(string house = "", string patronus = "", string school = "", string role = "");

        void InsertCharacter(string name, string role, string house, string patronus, string school);
    }
}