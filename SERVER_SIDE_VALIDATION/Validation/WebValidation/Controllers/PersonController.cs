using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebValidation.Models;

namespace WebValidation.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        // return model stete
        [HttpPost]
        public JsonResult InsertPerson(Person item) {

            ModelState.Remove("Description");

            if (!ModelState.IsValid)
            {
                return Json(ModelState, JsonRequestBehavior.AllowGet);
            }
            return Json("succeess", JsonRequestBehavior.AllowGet);
        }


        // return list of errors
        [HttpPost]
        public JsonResult InsertPerson2(Person model) {

            ValidationContext context = new ValidationContext(model, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            var errorList = new List<string>();
            // check is there errors
            if (!Validator.TryValidateObject(model, context, errors, true))
            {
                // get error list
                foreach (ValidationResult result in errors)
                {
                    errorList.Add(result.ErrorMessage);
                }

                return Json(errorList,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}