using Dapper;
using System.Data;
using System.Linq;
using HarryPotter.Data.DapperORM.Interface;
using HarryPotter.Model;
using System.Collections.Generic;

namespace HarryPotter.Data.DapperORM.Class
{
    public class CharacterRepository : BaseRepository, ICharacterRepository
    {
        public IEnumerable<Character> GetCharacters(string house = "", string patronus = "", string school = "", string role = "")
        {
            using var db = GetSqlConnection();
            var sql = @"SELECT id, name, role, house, patronus, school FROM HarryPotterDB.dbo.Character WHERE 1=1";

            if (house.Length > 0)
                sql += " AND house = @House";

            if (patronus.Length > 0)
                sql += " AND patronus = @Patronus";

            if (school.Length > 0)
                sql += " AND school = @School";

            if (role.Length > 0)
                sql += " AND role = @Role";

            return db.Query<Character>(sql, new { Role = role, School = school, House = house, Patronus = patronus }, commandType: CommandType.Text).ToList();
        }

        public void InsertCharacter(string name, string role, string house, string patronus, string school)
        {
            using var db = GetSqlConnection();
            const string sql = @"INSERT INTO HarryPotterDB.dbo.Character (name, role, school, house, patronus) values (@Name, @Role, @School, @House, @Patronus)";

            db.Execute(sql, new { Name = name, Role = role, School = school, House = house, Patronus = patronus}, commandType: CommandType.Text);
        }
    }
}