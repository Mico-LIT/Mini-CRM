using ForBiz.Models.Instagram;
using ForBiz.Models.Instagram.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ForBiz.Controllers
{
    public class HomeController : Controller
    {
        public static List<InstagramVm> DB = new List<InstagramVm>()
        {
                new InstagramVm() {
                    FIO ="Иванов Иван Иванович1",
                    URL = "https://www.instagram.com/offi_hanna/",
                    EndPoint = EndPointType.Instagram,
                    TimeStamp = DateTime.Now
                },

                new InstagramVm() {
                    FIO ="Иванов Иван Иванович2",
                    URL = "https://www.instagram.com/offi_hanna/",
                    EndPoint = EndPointType.Instagram,
                    TimeStamp = DateTime.Now
                },
                                new InstagramVm() {
                    FIO ="Иванов Иван Иванович3",
                    URL = "https://www.instagram.com/offi_hanna/",
                    EndPoint = EndPointType.Instagram,
                    TimeStamp = DateTime.Now
                }
    };


        // GET: Home
        public ActionResult Index()
        {
            return View(DB.OrderByDescending(x => x.TimeStamp).ToList());
        }

        [HttpPost]
        public ActionResult AddPerson(InstagramVm instagramVm)
        {
            DB.Add(instagramVm);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}