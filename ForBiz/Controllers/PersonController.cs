using ForBiz.Business.Modules.Persons.Dto;
using ForBiz.Business.Modules.Persons.Services;
using ForBiz.Core.Request;
using ForBiz.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utility.Business.Core.Exceptions;
using Utility.Business.Core.Page.Requests;
using Utility.Business.Core.Responses;

namespace ForBiz.Controllers
{
    [AuthorizHandler]
    public class PersonController : Controller
    {
        private Lazy<IPersonService> _personService;

        public PersonController(Lazy<IPersonService> personService)
        {
            _personService = personService;
        }

        // GET: SendingPeople
        [HttpGet]
        public ActionResult Index(PageRequest pageRequest)
        {
            return View(new PersonVm(_personService.Value.Get(pageRequest)));
        }

        [HttpPost]
        public JsonResult Page(PageRequest pageRequest)
        {
            return Json(new PersonVm(_personService.Value.Get(pageRequest)));
        }

        [HttpPost]
        public ActionResult AddPerson(PersonDto person)
        {
            try
            {
                _personService.Value.AddPerson(person);

                return Json(JsonResponse.CreateSuccess());
            }
            catch (Exception ex)
            {
                if (ex is ValidationException)
                    return Json(JsonResponse.CreateError(ex));

                return Json(JsonResponse.CreateError(ExceptionDictionary.Instance.GetUserFriendlyMessage(ex)));
            }
        }

        [HttpPost]
        public ActionResult DeletePerson(Guid personId)
        {
            _personService.Value.DeletePerson(personId);

            return Json(JsonResponse.CreateSuccess());
        }

        [HttpPost]
        public ActionResult SendPerson(Guid personId)
        {
            _personService.Value.SendPerson(personId);

            return Json(JsonResponse.CreateSuccess());
        }

        [HttpPost]
        public ActionResult UpdatePerson(PersonDto person)
        {
            try
            {
                _personService.Value.UpdatePerson(person);

                return Json(JsonResponse.CreateSuccess());
            }
            catch (Exception ex)
            {
                if (ex is ValidationException)
                    return Json(JsonResponse.CreateError(ex));

                return Json(JsonResponse.CreateError(ExceptionDictionary.Instance.GetUserFriendlyMessage(ex)));
            }
        }

        [HttpPost]
        public JsonResult FindPerson(PersonFindDto personFind, PageRequest pageRequest)
        {
            return Json(new PersonVm(_personService.Value.Find(personFind, pageRequest)));
        }
    }
}