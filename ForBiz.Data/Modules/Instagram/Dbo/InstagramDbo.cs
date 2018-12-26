using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBiz.Data.Modules.Instagram.Dbo
{
    public class InstagramDbo
    {
        public Guid Id { get; set; }
        public string Fio { get; set; }
        public string Url { get; set; }
        public int EndPoint { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
