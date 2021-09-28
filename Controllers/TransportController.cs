using SchoolAPI.Models.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    public class TransportController : ApiController
    {
        public ITransportInterface repository = new TransportRepository();
        // GET api/values
        [HttpGet]
        public Object GetUpdate(string sno)
        {
            return repository.GetUpdate(sno);
        }
        [Route("api/Transport/Verify")]
        [HttpGet]
        public Object Verify(string mobile, string regNo)
        {
            return repository.Verify(mobile, regNo);
        }
    }
}
