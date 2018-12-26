using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Data.Core.Page.Dbo
{
    public class PageDbo<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalCount { get; private set; }

        public PageDbo(IEnumerable<T> items, int totalCount)
        {
            this.Items = items;
            this.TotalCount = totalCount;
        }
    }
}
