using Dapper;
using System.Data;
using System.Linq;
using HarryPotter.Data.DapperORM.Interface;
using HarryPotter.Model;

namespace HarryPotter.Data.DapperORM.Class
{
    public class CharacterRepository : BaseRepository, ICharacterRepository
    {
        public void InsertCharacter(string name, string role, string house, string patronus, string school)
        {
            using var db = GetSqlConnection();
            const string sql = @"INSERT INTO HarryPotterDB.dbo.Character (name, role, school, house, patronus) values (@Name, @Role, @School, @House, @Patronus)";

            db.Execute(sql, new { Name = name, Role = role, School = school, House = house, Patronus = patronus}, commandType: CommandType.Text);
        }
    }
}