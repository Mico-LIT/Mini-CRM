using ForBiz.Models.Instagram.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ForBiz.Models.Instagram
{
    public class InstagramVm
    {
        public string FIO { get; set; }
        public string URL { get; set; }
        public EndPointType EndPoint { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}