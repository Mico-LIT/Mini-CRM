using ForBiz.Business.Modules.Instagram.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForBiz.Business.Modules.Instagram.Dto
{
    public class InstagramDto
    {
        public Guid Id { get; set; }
        public string Fio { get; set; }
        public string Url { get; set; }
        public EndPoin EndPoint { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
