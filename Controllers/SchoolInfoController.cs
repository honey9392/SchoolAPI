using SchoolAPI.Models.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    public class SchoolInfoController : ApiController
    {
        public IInformationInterface repository = new InformationRepository();
        
        [Route("api/SchoolInfo/GetUpdate")]
        [HttpGet]
        public Object GetUpdate(string sno)
        {
            return repository.GetUpdate(sno);
        }
    }
}
