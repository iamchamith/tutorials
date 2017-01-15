using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ALL.Controllers
{
    public class ErrorHandlingController : ApiController
    {

        //Http Error
        [HttpGet]
        public HttpResponseMessage ModelValidation()
        {

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "this is custom error");
        }

        [HttpGet]
        public HttpResponseMessage ModelValidation2()
        {

            var x = new Product
            {
                Id = 1,
                Name = "",
                Price = 123,
                Weight = -789
            };

            var e = new List<Errors>();
            if (!IsValidate.IsValied(x, out e))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(e));
            }

            return Request.CreateErrorResponse(HttpStatusCode.OK, "ok");
        }

        //HTTP RESPONSE EXCEPTION
        public string GetItemName() {

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }

    public class Errors
    {

        public string Field { get; set; }
        public string Error { get; set; }
    }

    public class IsValidate
    {

        public static bool IsValied(object x, out List<Errors> e)
        {
            ValidationContext context = new ValidationContext(x, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            e = new List<Errors>();
            if (!Validator.TryValidateObject(x, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    string d = result.ErrorMessage;
                    e.Add(new Errors { Error = result.ErrorMessage, Field = result.MemberNames.ToList().FirstOrDefault() });
                }
                return false;
            }
            return true;
        }
    }
}
