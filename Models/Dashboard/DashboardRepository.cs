using SchoolAPI.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Dashboard
{
    public class DashboardRepository : IDashboardInterface
    {
        SqlConnection con;
        public DashboardRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }

        public Object GetUpdate(string sno)
        {
            Result result = new Result();
            string query = string.Format(@"Dashboard @s_no = '" + sno+"'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Dashboard dashboard = new Dashboard();
                        dashboard.sNo = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        dashboard.studentName = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        dashboard.fatherName = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        dashboard.motherName = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        dashboard.classCurrent = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        dashboard.gender = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                        dashboard.address = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                        dashboard.homePhone = (reader.GetValue(7) != null) ? reader.GetString(7) : "NA";
                        dashboard.fatherPhone = (reader.GetValue(8) != null) ? reader.GetString(8) : "NA";
                        dashboard.dob = (reader.GetValue(9) != null) ? reader.GetString(9) : "NA";
                        dashboard.totalFee = (reader.GetValue(10) != null) ? reader.GetString(10) : "NA";
                        dashboard.feePaid = (reader.GetValue(11) != null) ? reader.GetString(11) : "NA";
                        dashboard.attendance = (reader.GetValue(12) != null) ? reader.GetString(12) : "NA";
                        dashboard.totalDays = (reader.GetValue(13) != null) ? reader.GetString(13) : "NA";
                        dashboard.lastResult = (reader.GetValue(14) != null) ? reader.GetString(14) : "NA";
                        dashboard.profileImage = "https://news.umanitoba.ca/wp-content/uploads/2019/03/IMG_9991-1200x800.jpg";
                        dashboard.absent = (reader.GetValue(15) != null) ? reader.GetString(15) : "NA";
                        dashboard.absent = (reader.GetValue(16) != null) ? reader.GetString(16) : "NA";
                        result.data.Add(dashboard);
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
            result.data_name = "dashboard";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
    }
}