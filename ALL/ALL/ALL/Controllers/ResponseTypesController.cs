using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ALL.Controllers
{

    //function sampleRequest()
    //{

    //$.ajax({
    //        url: '/api/ResponseTypes/SessionIsNotValied',
    //    method: 'get',
    //    success: (e) => {
    //        alert(JSON.stringify(e));
    //    },
    //    error: (e) => {
    //        HandleError(e);
    //    },
    //});

    //}

    //function HandleError(e)
    //{
    //    alert(e.statusText);
    //    if (e.status === 500)
    //    {
    //        alert(e.statusText);
    //    }
    //    else if (e.status === 404)
    //    {
    //        alert('redert to 404 page');
    //    }
    //    else if (e.status === 405)
    //    {
    //        alert('redert to login page');
    //    }
    //}


    public class ResponseTypesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage OkMessage()
        {

            return Request.CreateResponse<StudentViewModel>(HttpStatusCode.OK, new StudentViewModel
            {
                Id = 1,
                Message = "he is good boy",
                Name = "Chamith"
            }); ;
        }

        [HttpGet]
        public HttpResponseMessage ErrorMessage()
        {

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "server side error happen");
        }
        [HttpGet]
        public HttpResponseMessage SessionIsNotValied()
        {

            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "unauthorised");
        }
        [HttpGet]
        public HttpResponseMessage _404()
        {

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "404");
        }

        [HttpGet]
        public void PostData(int id = 0)
        {
            if (id!=0)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
           
        }
    }

    public class StudentViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }


}
