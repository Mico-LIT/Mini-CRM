using ForBiz.Business.Modules.Instagram.Dto;
using ForBiz.Business.Modules.Instagram.Services;
using ForBiz.Models.Instagram;
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
        private Lazy<IInstagramService> _instagramService;

        public HomeController(Lazy<IInstagramService> instagramService)
        {
            _instagramService = instagramService;
        }

        // GET: Home
        [HttpGet]
        public ActionResult Index(PageRequest pageRequest)
        {
            return View(new InstagramVm(_instagramService.Value.Get(pageRequest)));
        }

        [HttpPost]
        public JsonResult Page(PageRequest pageRequest)
        {
            return Json(new InstagramVm(_instagramService.Value.Get(pageRequest)));
        }

        [HttpPost]
        public ActionResult AddPerson(InstagramDto instagramDto)
        {
            _instagramService.Value.AddPerson(instagramDto);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult DeletePerson(Guid Id)
        {
            _instagramService.Value.DeletePerson(Id);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult UpdatePerson(InstagramDto instagramDto)
        {
            _instagramService.Value.UpdatePerson(instagramDto);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public JsonResult FindPerson(InstagramFindDto instagramFind, PageRequest pageRequest)
        {
            return Json(new InstagramVm(_instagramService.Value.Find(instagramFind, pageRequest)));
        }
    }
}