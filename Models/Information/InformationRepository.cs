using SchoolAPI.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Information
{
    public class InformationRepository : IInformationInterface
    {
        SqlConnection con;
        public InformationRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }
        public object GetUpdate(string sno)
        {
            Result result = new Result();
            string query = string.Format(@"[GetTypeData] 'GetSchoolInfo'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    var info = new Dictionary<string, string>();
                    
                    while (reader.Read())
                    {
                        info.Add((reader.GetValue(0) != null) ? reader.GetString(0) : "NA", (reader.GetValue(1) != null) ? reader.GetString(1) : "NA");                        
                    }
                    info.Add("SchoolImage", ConfigurationManager.AppSettings["BaseAPIurl"] + "/Image/Schoollogo.png");
                    result.data.Add(info);
                }
                else
                {
                    result.message = "No Data Found";
                }
                con.Close();
            }
            result.status = 1;
            result.count = result.data.Count;
            result.data_name = "school_information";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
    }
}