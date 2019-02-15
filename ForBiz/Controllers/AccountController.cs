using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ForBiz.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            if (ConfigurationManager.AppSettings["Token"] == (string)HttpContext.Session["Token"])
            {
                return Redirect("/Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationApiKey(string userName, string userPass)
        {
            var user = new
            {
                UserName = ConfigurationManager.AppSettings["UserName"],
                UserPass = ConfigurationManager.AppSettings["UserPass"],
                Token = ConfigurationManager.AppSettings["Token"]
            };

            if (user.UserName == userName && user.UserPass == userPass)
            {
                HttpContext.Session["Token"] = user.Token;
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Не верный пароль и логин");
                return View("Login");
            }
        }
    }
}