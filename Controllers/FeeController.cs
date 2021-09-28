using SchoolAPI.Models.Fee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    public class FeeController : ApiController
    {
        public IFeeInterface repository = new FeeRepository();
        // GET api/values
        [HttpGet]
        public Object GetUpdate(string sno)
        {
            return repository.GetUpdate(sno);
        }

        [Route("api/Fee/Installments")]
        [HttpGet]
        public Object Installments(string sno)
        {
            return repository.GetInstallments(sno);
        }
    }
}
