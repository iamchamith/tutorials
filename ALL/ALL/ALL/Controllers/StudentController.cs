using DbService.Infrastructure;
using DbService.Repository;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ALL.Controllers
{
    public class StudentController : ApiController
    {
        private IStudentRepository unitOfWork;

        public StudentController(IStudentRepository _unitOfWork)
        {

            this.unitOfWork = _unitOfWork;
        }

        [HttpGet]
        [Route("ddd")]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(this.unitOfWork.Get(orderBy: q => q.OrderBy(p => p.Id))))
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(this.unitOfWork.GetByID(id)))
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Insert(Student obj)
        {
            try
            {
                this.unitOfWork.Insert(obj);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update(Student obj)
        {
            try
            {
                this.unitOfWork.Update(obj);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }

        [HttpPost]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                this.unitOfWork.Delete(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }

        [HttpGet]
        public HttpResponseMessage GetStudentCount()
        {

            try
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(this.unitOfWork.RecodeCount()))
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
            }
        }
    }
}
