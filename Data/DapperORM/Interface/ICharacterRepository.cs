using HarryPotter.Model;

namespace HarryPotter.Data.DapperORM.Interface
{
    public interface ICharacterRepository
    {
        //Character GetCharacters();

        void InsertCharacter(string name, string role, string house, string patronus, string school);
    }
}