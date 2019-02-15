using ForBiz.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utility.Business.Core.Page.Requests;

namespace ForBiz.Controllers
{
    [AuthorizHandler]
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index(PageRequest pageRequest)
        {
            return View();
        }
    }
}