using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ROUTING.API
{
    public class TicketController : ApiController
    {
        [HttpGet]
        [Route("Ticket")]
        public List<Tickets> Get() {
            var lst = new List<Tickets>();
            for (int i = 0; i < 10; i++)
            {
                lst.Add(new Tickets { Id = i, Name = $"Name {i}", Address = $"Address {i}" });
            }
            return lst;
        }
        [HttpGet]
        [Route("Ticket")]
        public Tickets Get(int id) {
            return new Tickets { Id = 12, Name = $"Name {12}", Address = $"Address {12}" };
        }
        [HttpPost]
        [Route("Ticket")]
        public Tickets Post(Tickets item) {
            return item;
        }

        [HttpPut]
        [Route("Ticket")]
        public bool Put(Tickets item) {
            return true;
        }

        [HttpDelete]
        [Route("Ticket")]
        public bool Delete(int id) {
            return true;
        }

    }

    public class Tickets {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
