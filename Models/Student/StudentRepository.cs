using SchoolAPI.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SchoolAPI.Models.Student
{
    public class StudentRepository : IStudentInterface
    {
        SqlConnection con;
        public StudentRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }

        public Object GetAll()
        {
            Result result = new Result();
            string query = string.Format("Select * From appform Where Class LIKE 'IV - A'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Student category = new Student();
                        //category.Id = (reader.GetValue(0) != null) ? int.Parse(reader.GetInt32(0).ToString()) : 0;
                        category.studentName = (reader.GetValue(1) != null) ? reader.GetString(1) : "Null";
                        result.data.Add(category);
                    }
                }
                else
                {
                    result.message = "No Data Found";
                }
                con.Close();
            }
            result.status = 1;
            result.count = result.data.Count;
            result.data_name = "Category";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }

        public Object GetUpdate(string sno)
        {
            Result result = new Result();
            string query = string.Format(@"Select ISNULL(s_no,'NA') sNo,ISNULL(studName,'NA') studentName,ISNULL(FName,'NA') fatherName,ISNULL(MName,'NA') motherName,ISNULL(Class,'NA') classCurrent,ISNULL(Gender,'NA') gender,ISNULL(h_address,'NA') address,ISNULL(h_ph,'NA') homePhone,ISNULL(fMobile,'NA') fatherPhone,ISNULL(CAST(dob AS NVARCHAR(200)),'NA') dob,ISNULL(studying,'NA') isStudying From appform Where studying = 'Y' AND s_no = '" + sno+"'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.sNo = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        student.studentName = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        student.fatherName = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        student.motherName = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        student.classCurrent = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        student.gender = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                        student.address = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                        student.homePhone = (reader.GetValue(7) != null) ? reader.GetString(7) : "NA";
                        student.fatherPhone = (reader.GetValue(8) != null) ? reader.GetString(8) : "NA";
                        student.dob = (reader.GetValue(9) != null) ? reader.GetString(9) : "NA";
                        student.isStudying = (reader.GetValue(10) != null) ? reader.GetString(10) : "NA";
                        student.profileImage = "https://news.umanitoba.ca/wp-content/uploads/2019/03/IMG_9991-1200x800.jpg";
                        result.data.Add(student);
                    }
                }
                else
                {
                    result.message = "No Data Found";
                }
                con.Close();
            }
            result.status = 1;
            result.count = result.data.Count;
            result.data_name = "student";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }

        public Object GetBirthday(string sno)
        {
            Result result = new Result();
            string query = string.Format(@"[GetTypeData] 'GetBirthday','" + sno + "'");
            string queryForUpComingBday = string.Format(@"[GetTypeData] 'GetBirthdayForCurrentMonth','" + sno + "'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.sNo = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        student.studentName = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        student.fatherName = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        student.motherName = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        student.classCurrent = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        student.gender = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                        student.address = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                        student.homePhone = (reader.GetValue(7) != null) ? reader.GetString(7) : "NA";
                        student.fatherPhone = (reader.GetValue(8) != null) ? reader.GetString(8) : "NA";
                        student.dob = (reader.GetValue(9) != null) ? reader.GetString(9) : "NA";
                        student.isStudying = (reader.GetValue(10) != null) ? reader.GetString(10) : "NA";
                        student.profileImage = "https://news.umanitoba.ca/wp-content/uploads/2019/03/IMG_9991-1200x800.jpg";
                        result.data.Add(student);
                    }
                }
                else
                {
                    result.message = "No Data Found";
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand(queryForUpComingBday, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.sNo = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        student.studentName = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        student.fatherName = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        student.motherName = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        student.classCurrent = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        student.gender = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                        student.address = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                        student.homePhone = (reader.GetValue(7) != null) ? reader.GetString(7) : "NA";
                        student.fatherPhone = (reader.GetValue(8) != null) ? reader.GetString(8) : "NA";
                        student.dob = (reader.GetValue(9) != null) ? reader.GetString(9) : "NA";
                        student.isStudying = (reader.GetValue(10) != null) ? reader.GetString(10) : "NA";
                        result.data.Add(student);
                    }
                }
                con.Close();
            }
            result.status = 1;
            result.count = result.data.Count;
            result.data_name = "student birthday";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }

        public Object Verify(string username, string password)
        {
            Result result = new Result();
            string query = string.Format(@"[VerifyUser] @Useremail='{0}' ,@Password='{1}'",username,password);
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                string Result = (cmd.ExecuteScalar()).ToString();
                if (Result != "-101")//(reader.HasRows)
                {
                    result.message = "Data Found";
                    //while (reader.Read())
                    if(Result != "-101")
                    {
                        
                        Student student = new Student();
                        student.sNo = Result.ToString();//(reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        //student.studentName = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        //student.fatherName = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        //student.motherName = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        //student.classCurrent = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        //student.gender = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                        //student.address = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                        //student.homePhone = (reader.GetValue(7) != null) ? reader.GetString(7) : "NA";
                        //student.fatherPhone = (reader.GetValue(8) != null) ? reader.GetString(8) : "NA";
                        //student.dob = (reader.GetValue(9) != null) ? reader.GetString(9) : "NA";
                        //student.isStudying = (reader.GetValue(10) != null) ? reader.GetString(10) : "NA";
                        student.session = "2020-2021";
                        result.data.Add(student);
                    }
                }
                else
                {
                    result.message = "No Data Found";
                }
                con.Close();
            }
            result.status = 1;
            result.count = result.data.Count;
            result.data_name = "user_verification";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
        public Object VerifyAdmin(string username, string password)
        {
            Result result = new Result();
            string query = string.Format(@"Select Useremail='{0}' ,Password='{1}'", username, password);
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                string Result = (cmd.ExecuteScalar()).ToString();
                if (Result != "-101")//(reader.HasRows)
                {
                    result.message = "Data Found";
                    //while (reader.Read())
                    if (Result != "-101")
                    {
                        Student student = new Student();
                        student.sNo = Result.ToString();
                        student.session = "2020-2021";
                        result.data.Add(student);
                    }
                }
                else
                {
                    result.message = "No Data Found";
                }
                con.Close();
            }
            result.status = 1;
            result.count = result.data.Count;
            result.data_name = "user_verification";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
        public Object ChangePassword(User user)
        {
            Object objResult = Verify(user.userName,user.password);
            Result result = (Result)objResult;
            string query = string.Format(@"[InUpDeUser] @sno='{0}',@Useremail='{1}' ,@oldPassword='{2}' , @newPassword='{3}'", user.sNo, user.userName, user.password , user.newPassword);

            if (result.message == "Data Found" && result.data.Count > 0)
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    string Result = (cmd.ExecuteScalar()).ToString();
                    if (Result == "200")//(reader.HasRows)
                    {
                        result.message = "Password Changed Successfully!";
                        result.status = 1;
                    }
                    else
                    {
                        result.message = "No User Found With These Credentials!";
                        result.status = 0;
                    }
                    con.Close();
                }
                result.count = result.data.Count;
                result.data_name = "credentials_update";
                result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
                return result;
            }
            else
            {
                result.message = "No User Found With These Credentials!";
                result.count = result.data.Count;
                result.data_name = "credentials_update";
                result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
                result.status = 0;
                return result;
            }
        }

        public Object SendCredentials(string mobileNo)
        {
            Result result = new Result();
            //string query = string.Format(@"Select username,password From appform Where h_ph='{0}'", mobileNo);
            string query = string.Format(@"Select username,password From appform Where h_ph='{0}'", "9784574701");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        string userName = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        string passWord = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        //SendSMS(userName, passWord);
                        SendSMS(mobileNo, passWord);
                    }
                }
                else
                {
                    result.message = "No Data Found";
                }
                con.Close();
            }
            result.status = 1;
            result.count = result.data.Count;
            result.data_name = "user_verification";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }

        public void SendSMS(string uName, string pWord)
        {

            string URL = "http://new.rajbusiness.com/api/mt/SendSMS?user=#U#^password=#P#^senderid=#S#^channel=Trans^DCS=0^flashsms=0^number=#T#^text=#M#^route=01";
            URL = URL.Replace("^", "&");
            URL = URL.Replace("#U#", "Eduapplications");
            URL = URL.Replace("#P#", "EDUapp");
            URL = URL.Replace("#S#", "EDUAPP");
            URL = URL.Replace("#T#", uName);
            URL = URL.Replace("#M#", "Username : " + uName + " \nPassword : " + pWord);
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();

        }

    }
}