using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForBiz.Data.Modules.Persons.Dbo;
using ForBiz.Data.Modules.Persons.Models;
using Utility.Data.Core.Page.Dbo;
using Utility.Data.Core.Page.Models;
using Utility.Data.Core.Repositories;

namespace ForBiz.Data.Modules.Persons.Repositories
{
    public class PersonRetository : BaseRepository, IPersonRepository
    {
        public void AddPerson(PersonDbo person)
        {
            Execute(@"
            INSERT Person 
  (Id, Name, Instagram, Vk, Email, TimeStamp)
  VALUES 
  (
  DEFAULT,
 @Name,
 @Instagram,
 @Vk,
 @Email,
 DEFAULT);", person);
        }

        public void DeletePerson(Guid personId)
        {
            Execute("DELETE Person WHERE Id = @Id", new { Id = personId });
        }

        public PageDbo<PersonDbo> Find(PersonFind personFind, int page, int size)
        {
            List<string> wheres = new List<string>();

            string sqlFrom = " from Person p ";
            string sqlOrderBy = " order by p.TimeStamp desc ";

            PageSkipTakeModel pageSkipTake = new PageSkipTakeModel(page, size);

            if (!string.IsNullOrWhiteSpace(personFind.Instagram)) wheres.Add(string.Format(" p.Instagram like('%{0}%') ", personFind.Instagram));
            if (!string.IsNullOrWhiteSpace(personFind.Vk)) wheres.Add(string.Format(" p.Vk like('%{0}%') ", personFind.Vk));
            if (!string.IsNullOrWhiteSpace(personFind.Email)) wheres.Add(string.Format(" p.Email like('%{0}%') ", personFind.Email));
            if (!string.IsNullOrWhiteSpace(personFind.Name)) wheres.Add(string.Format(" p.Name like('%{0}%') ", personFind.Name));

            string sql = sqlFrom + base.ConcatWhere(wheres);

            IEnumerable<PersonDbo> items;
            int totalCount;

            using (var conn = base.OpenConnection())
            {
                items = Query<PersonDbo>(conn, "select * " + sql + sqlOrderBy + pageSkipTake.SqlFormat, null);

                totalCount = QueryFirst<int>(conn, "select Count(*) " + sql, null);
            }

            return new PageDbo<PersonDbo>(items, totalCount);
        }

        public List<PersonDbo> Find(PersonFind personFind)
        {
            List<string> wheres = new List<string>();

            string sqlFrom = " from Person p ";

            if (!string.IsNullOrWhiteSpace(personFind.Instagram)) wheres.Add(string.Format(" p.Instagram like('%{0}%') ", personFind.Instagram));
            if (!string.IsNullOrWhiteSpace(personFind.Vk)) wheres.Add(string.Format(" p.Vk like('%{0}%') ", personFind.Vk));
            if (!string.IsNullOrWhiteSpace(personFind.Email)) wheres.Add(string.Format(" p.Email like('%{0}%') ", personFind.Email));
            //if (!string.IsNullOrWhiteSpace(personFind.Name)) wheres.Add(string.Format(" p.Name like('%{0}%') ", personFind.Name));

            string sql = sqlFrom + base.ConcatWhere(wheres);

            IEnumerable<PersonDbo> items;

            using (var conn = base.OpenConnection())
            {
                items = Query<PersonDbo>(conn, "select * " + sql, null);
            }

            return items.ToList();
        }

        public PageDbo<PersonDbo> Get(int page, int size)
        {
            string sqlSelect = "select * from Person ";
            string sqlTotalCount = "select Count(*) as count from Person";

            string sqlOrderBy = "order by TimeStamp desc";

            var skipTakeModel = new PageSkipTakeModel(page, size);

            string sql = string.Format("{0} {1} {2}", sqlSelect, sqlOrderBy, skipTakeModel.SqlFormat);

            IEnumerable<PersonDbo> items;
            int totalCount;

            using (var conn = base.OpenConnection())
            {
                items = Query<PersonDbo>(conn, sql, null);
                totalCount = QueryFirst<int>(conn, sqlTotalCount, null);
            }

            return new PageDbo<PersonDbo>(items, totalCount);
        }

        public void SendPerson(Guid personId)
        {
            base.Execute(@"UPDATE p SET p.TimeSending = GETDATE()
                           FROM Person p WHERE p.Id = @Id", new { Id = personId });
        }

        public void UpdatePerson(PersonDbo person)
        {
            Execute(@"
             UPDATE p
                SET p.Name = @Name,
                p.Instagram = @Instagram,
                p.Vk = @Vk,
                p.Email = @Email,
                p.TimeUpdate = GETDATE()
                FROM Person p
                WHERE p.Id = @Id", person);
        }
    }
}
