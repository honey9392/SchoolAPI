using SchoolAPI.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolAPI.Controllers
{
    public class StudentController : ApiController
    {
        public IStudentInterface repository = new StudentRepository();
        // GET api/values
        [HttpGet]
        public Object GetUpdate(string sno)
        {
            return repository.GetUpdate(sno);
        }
        [Route("api/Student/GetBirthday")]
        [HttpGet]
        public Object GetBirthday(string sno)
        {
            return repository.GetBirthday(sno);
        }
        [Route("api/Student/Verify")]
        [HttpGet]
        public Object Verify(string username,string password)
        {
            if (username.ToLower().Trim() == "admin".ToLower().Trim())
            {
                return repository.VerifyAdmin(username, password);
            }
            else
            {
                return repository.Verify(username, password);
            }
            
        }
        [Route("api/Student/ChangePassword")]
        [HttpPost]
        public Object ChangePassword(User user)
        {
            return repository.ChangePassword(user);
        }
        [Route("api/Student/SendCredentials")]
        [HttpGet]
        public Object SendCredentials(string mobileNo)
        {
            return repository.SendCredentials(mobileNo);
        }
    }
}
