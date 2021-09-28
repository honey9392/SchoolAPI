using SchoolAPI.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Attendance
{
    public class AttendanceRepository : IAttendanceInterface
    {
        SqlConnection con;
        public AttendanceRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }
        public Object GetUpdate(string sno)
        {
            Result result = new Result();
            string query = string.Format(@"InUpDeSeAttendance @StatementType ='Get',@s_no ='" + sno + "'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Attendance attendance = new Attendance();
                        attendance.sNo = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        attendance.classCurrent = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        attendance.Id = (reader.GetInt32(2) != 0) ? reader.GetInt32(2) : 0;
                        attendance.date = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        attendance.attendanceMark = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        attendance.color = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                        attendance.staffType = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                        result.data.Add(attendance);
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
            result.data_name = "attendance";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
    }
}