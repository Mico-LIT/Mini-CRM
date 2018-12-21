using ForBiz.Models.Instagram.Constans;
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
        public static List<Instagram> instagramsDB;

        public PageDto<Instagram> Page { get; set; }

        public InstagramVm(PageRequest pageRequest)
        {
            if (instagramsDB == null)
            {
                instagramsDB = TestPersons();
            }

            Page = new PageDto<Instagram>(instagramsDB
                .OrderByDescending(x => x.TimeStamp)
                .Skip((pageRequest.Page * pageRequest.Size) - pageRequest.Size)
                .Take(pageRequest.Size)
                .ToList(), pageRequest, instagramsDB.Count);
        }

        public void PageRequest(PageRequest pageRequest)
        {
            Page = new PageDto<Instagram>(instagramsDB
                .OrderByDescending(x => x.TimeStamp)
                .Skip((pageRequest.Page * pageRequest.Size) - pageRequest.Size)
                .Take(pageRequest.Size)                
                .ToList(), pageRequest, instagramsDB.Count);
        }

        public List<Instagram> TestPersons()
        {
            var persons = new List<Instagram>();

            for (int i = 0; i < 13; i++)
            {
                persons.Add(new Instagram()
                {
                    Id = Guid.NewGuid(),
                    FIO = "Иванов Иван Иванович_" + i,
                    URL = "https://www.instagram.com/offi_hanna/",
                    EndPoint = EndPointType.Instagram,
                    TimeStamp = DateTime.Now
                });
            }

            return persons;
        }
    }
}