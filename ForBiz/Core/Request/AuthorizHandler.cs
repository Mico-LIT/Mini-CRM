using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ForBiz.Core.Request
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AuthorizHandler : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToString();
            //string actionName = filterContext.ActionDescriptor.ActionName.ToString();
            //var headers = filterContext.RequestContext.HttpContext.Request.Headers;

            var apiKey = (string)filterContext.HttpContext.Session["Token"];

            if (ConfigurationManager.AppSettings["Token"] != apiKey)
            {
                if (filterContext.RequestContext.HttpContext.Request.ContentType == "application/json;charset=UTF-8")
                {
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    return;
                }

                filterContext.Result = new RedirectResult("Account/Login");
                return;
            }
        }
    }
}