using SchoolAPI.Models.Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    public class HomeworkController : ApiController
    {
        public IHomewokInterface repository = new HomeworkRepository();

        [Route("api/Homework/GetUpdate")]
        [HttpGet]
        public Object GetUpdate(string sno)
        {
            return repository.GetUpdate(sno);
        }
    }
}
