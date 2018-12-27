using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForBiz.Data.Modules.Instagram.Dbo;
using ForBiz.Data.Modules.Instagram.Models;
using Utility.Data.Core.Page.Dbo;
using Utility.Data.Core.Page.Models;
using Utility.Data.Core.Repositories;

namespace ForBiz.Data.Modules.Instagram.Repositories
{
    public class InstagramRetository : BaseRepository, IInstagramRepository
    {
        public void AddPerson(InstagramDbo instagram)
        {
            Execute(@"
            INSERT INTO dbo.Instagram(Id,Fio,Url,EndPoint,TimeStamp)
            VALUES
            (
              DEFAULT -- Id - uniqueidentifier NOT NULL
             ,@Fio -- Fio - nvarchar(200)
             ,@Url -- Url - nvarchar(max)
             ,@EndPoint -- EndPoint - tinyint
             ,DEFAULT -- 'YYYY-MM-DD hh:mm:ss[.nnn]'-- TimeStamp - datetime 
            );", instagram);
        }

        public void DeletePerson(Guid Id)
        {
            Execute("DELETE Instagram WHERE Id = @Id", new { Id });
        }

        public PageDbo<InstagramDbo> Find(InstagramFind instagramFind, int page, int size)
        {
            List<string> wheres = new List<string>();

            string sqlFrom = " from Instagram inst ";
            string sqlOrderBy = " order by inst.TimeStamp desc ";

            PageSkipTakeModel pageSkipTake = new PageSkipTakeModel(page, size);

            if (!string.IsNullOrWhiteSpace(instagramFind.Fio)) wheres.Add(string.Format(" inst.Fio like('%{0}%') ", instagramFind.Fio));
            if (!string.IsNullOrWhiteSpace(instagramFind.Url)) wheres.Add(string.Format(" inst.Url like('%{0}%') ", instagramFind.Url));
            if (instagramFind.EndPoint > 0) wheres.Add(string.Format(" inst.EndPoint = {0} ", instagramFind.EndPoint));

            string sql = sqlFrom + base.ConcatWhere(wheres);

            IEnumerable<InstagramDbo> items;
            int totalCount;

            using (var conn = base.OpenConnection())
            {
                items = Query<InstagramDbo>(conn, "select * " + sql + sqlOrderBy + pageSkipTake.SqlFormat, null);

                totalCount = QueryFirst<int>(conn, "select Count(*) " + sql, null);
            }

            return new PageDbo<InstagramDbo>(items, totalCount);
        }

        public PageDbo<InstagramDbo> Get(int page, int size)
        {
            string sqlSelect = "select * from Instagram inst";
            string sqlTotalCount = "select Count(*) as count from Instagram inst";

            string sqlOrderBy = "order by inst.TimeStamp desc";

            var skipTakeModel = new PageSkipTakeModel(page, size);

            string sql = string.Format("{0} {1} {2}", sqlSelect, sqlOrderBy, skipTakeModel.SqlFormat);

            IEnumerable<InstagramDbo> items;
            int totalCount;

            using (var conn = base.OpenConnection())
            {
                items = Query<InstagramDbo>(conn, sql, null);
                totalCount = QueryFirst<int>(conn, sqlTotalCount, null);
            }

            return new PageDbo<InstagramDbo>(items, totalCount);
        }

        public void UpdatePerson(InstagramDbo instagram)
        {
            Execute(@"
              UPDATE i
                SET i.Fio = @Fio,
                i.Url = @Url,
                i.EndPoint = @EndPoint,
                i.TimeStamp = DEFAULT
                FROM Instagram i
                WHERE i.Id = @Id", instagram);
        }
    }
}
