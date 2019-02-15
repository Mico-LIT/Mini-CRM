using ForBiz.Business.Modules.Persons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Utility.Business.Core.Page.Dto;
using Utility.Business.Core.Page.Requests;

namespace ForBiz.Models.Persons
{
    public class PersonVm
    {
        public PageDto<PersonDto> Page { get; set; }

        public PersonVm(PageDto<PersonDto> items)
        {
            Page = items;
        }
    }
}