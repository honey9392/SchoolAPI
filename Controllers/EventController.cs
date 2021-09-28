using SchoolAPI.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    public class EventController : ApiController
    {
        public IEventInterface repository = new EventRepository();
        // GET api/values
        [HttpGet]
        public Object GetUpdate(string sno)
        {
            return repository.GetUpdate(sno);
        }
    }
}
