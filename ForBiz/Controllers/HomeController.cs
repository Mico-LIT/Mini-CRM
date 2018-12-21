using ForBiz.Models.Instagram;
using ForBiz.Models.Instagram.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utility.Business.Core.Page.Requests;

namespace ForBiz.Controllers
{
    public class HomeController : Controller
    {
        public static InstagramVm DB = null;

        // GET: Home
        public ActionResult Index(PageRequest pageRequest)
        {
            DB = new InstagramVm(pageRequest);
            return View(DB);
        }

        [HttpPost]
        public JsonResult Page(PageRequest pageRequest)
        {
            DB.PageRequest(pageRequest);

            return Json(DB.Page.Items);
        }

        [HttpPost]
        public ActionResult AddPerson(Instagram person)
        {
            person.Id = Guid.NewGuid();
            InstagramVm.instagramsDB.Add(person);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult DeletePerson(Guid Id)
        {
            InstagramVm.instagramsDB.Remove(InstagramVm.instagramsDB.First(x => x.Id == Id));

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult UpdatePerson(Instagram instagramVm)
        {
            var person = InstagramVm.instagramsDB.First(x => x.Id == instagramVm.Id);

            if (person != null)
            {
                person.FIO = instagramVm.FIO;
                person.EndPoint = instagramVm.EndPoint;
                person.URL = instagramVm.URL;
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}