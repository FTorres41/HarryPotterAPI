using Dapper;
using System.Data;
using System.Linq;
using HarryPotter.Data.DapperORM.Interface;
using HarryPotter.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using System;

namespace HarryPotter.Data.DapperORM.Class
{
    public class CharacterRepository : BaseRepository, ICharacterRepository
    {
        public bool DeleteCharacter(string id)
        {
            using var db = GetSqlConnection();
            var sql = @"DELETE FROM dbHarryPotter.dbo.Character WHERE id = @Id";

            var result = db.Execute(sql, new { Id = new Guid(id) }, commandType: CommandType.Text);

            if (result <= 0)
                return false;
            else
                return true;
        }

        public Character GetCharacterById(string id)
        {
            using var db = GetSqlConnection();
            var sql = @"SELECT id, name, role, house, patronus, school FROM dbHarryPotter.dbo.Character WHERE id = @Id ";

            return db.Query<Character>(sql, new { Id = id }, commandType: CommandType.Text).FirstOrDefault();
        }

        public IEnumerable<Character> GetCharacters(string house = "", string patronus = "", string school = "", string role = "")
        {
            using var db = GetSqlConnection();
            var sql = @"SELECT id, name, role, house, patronus, school FROM dbHarryPotter.dbo.Character WHERE 1=1";

            if (house != null && house.Length > 0)
                sql += " AND house = @House";

            if (patronus != null && patronus.Length > 0)
                sql += " AND patronus = @Patronus";

            if (school != null && school.Length > 0)
                sql += " AND school = @School";

            if (role != null && role.Length > 0)
                sql += " AND role = @Role";

            return db.Query<Character>(sql, new { Role = role, School = school, House = house, Patronus = patronus }, commandType: CommandType.Text).ToList();
        }

        public bool InsertCharacter(string name, string role, string house, string patronus, string school)
        {
            using var db = GetSqlConnection();
            const string sql = @"INSERT INTO dbHarryPotter.dbo.Character (id, name, role, school, house, patronus) values (@Id, @Name, @Role, @School, @House, @Patronus)";

            var result = db.Execute(sql, new { Id = Guid.NewGuid(), Name = name, Role = role, School = school, House = house, Patronus = patronus}, commandType: CommandType.Text);

            if (result <= 0)
                return false;
            else
                return true;
        }

        public bool UpdateCharacter(Character characterToUpdate)
        {
            using var db = GetSqlConnection();
            const string sql = @"UPDATE dbHarryPotter.dbo.Character SET name = @Name, role = @Role, school = @School, house = @House, patronus = @Patronus WHERE id = @Id";

            var result = db.Execute(sql, new { Id = characterToUpdate.Id, Name = characterToUpdate.Name, Role = characterToUpdate.Role, School = characterToUpdate.School, House = characterToUpdate.House, Patronus = characterToUpdate.Patronus }, commandType: CommandType.Text);

            if (result <= 0)
                return false;
            else
                return true;
        }
    }
}