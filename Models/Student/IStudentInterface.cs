using System;

namespace SchoolAPI.Models.Student
{
    public interface IStudentInterface
    {
        Object GetAll();
        Object GetUpdate(string s_no);
        Object GetBirthday(string s_no);
        Object Verify(string username, string password);
        Object ChangePassword(User user);
        Object VerifyAdmin(string username, string password);
        Object SendCredentials(string mobileNo);
    }
}
