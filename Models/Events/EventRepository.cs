using SchoolAPI.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Event
{
    public class EventRepository : IEventInterface
    {
        SqlConnection con;
        public EventRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }

        public Object GetUpdate(string sno)
        {
            Result result = new Result();
            string query = string.Format(@"InUpDeSeEvent @StatementType ='Get',@s_no ='" + sno + "'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Events events = new Events();
                        events.Id = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        events.toDate = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        events.fromDate = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        events.eventName = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        events.remark = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        result.data.Add(events);
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
            result.data_name = "events";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
    }
}