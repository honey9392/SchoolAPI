using SchoolAPI.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Homework
{
    public class HomeworkRepository : IHomewokInterface
    {
        SqlConnection con;
        public HomeworkRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }

        public object GetUpdate(string s_no)
        {
            Result result = new Result();
            string query = string.Format(@"GetHomework @StatementType ='Get',@s_no ='" + s_no + "'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Homework homework = new Homework();
                        homework.sNo = s_no;
                        homework.heading = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        homework.description = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        homework.subject = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        homework.Class = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        homework.CreatedOn = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        homework.Active = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                        homework.CreatedBy = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                        homework.filePath = ConfigurationManager.AppSettings["BaseWEBurl"] + ((reader.GetValue(7) != null) ? reader.GetString(7) : "NA").Replace("~","");
                        result.data.Add(homework);
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
            result.data_name = "homework";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
    }
}