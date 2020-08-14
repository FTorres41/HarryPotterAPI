using System.Collections.Generic;
using HarryPotter.Data.DapperORM.Interface;
using HarryPotter.Model;
using HarryPotter.Service.Interface;

namespace HarryPotter.Service.Class
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public void InsertCharacter(string name, string role, string patronus, string school, string house)
        {
            
        }
    }
}