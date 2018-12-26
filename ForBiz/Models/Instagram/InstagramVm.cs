using ForBiz.Business.Modules.Instagram.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Utility.Business.Core.Page.Dto;
using Utility.Business.Core.Page.Requests;

namespace ForBiz.Models.Instagram
{
    public class InstagramVm
    {
        public PageDto<InstagramDto> Page { get; set; }

        public InstagramVm(PageDto<InstagramDto> items)
        {
            Page = items;
        }
    }
}