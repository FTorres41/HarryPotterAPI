using System.Collections.Generic;
using HarryPotter.Model;

namespace HarryPotter.Service.Interface
{
    public interface ICharacterService
    {
        void InsertCharacter(string name, string role, string patronus, string school, string house);
    }
}