using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Data.Core.Page.Models
{
    public class PageSkipTakeModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Sql => " offset @Skip rows fetch next @Take rows only ";
        public string SqlFormat => string.Format("offset {0} rows fetch next {1} rows only", Skip, Take);

        public PageSkipTakeModel(int page, int size)
        {
            this.Skip = (page - 1) * size;
            this.Take = size;
        }
    }
}
