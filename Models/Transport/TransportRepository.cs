using SchoolAPI.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Transport
{
    public class TransportRepository : ITransportInterface
    {
        SqlConnection con;
        public TransportRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }

        public object GetUpdate(string sno)
        {
            Result result = new Result();
            string query = string.Format(@"InUpDeSeTransport @StatementType ='Get',@s_no ='" + sno + "'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Transport transport = new Transport();
                        transport.vehID = (reader.GetValue(0) != null) ? reader.GetInt32(0) : 0;
                        transport.sNo = sno;
                        transport.regNo = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        transport.vehType = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        transport.driverName = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        transport.phoneNo = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        transport.alternativeNo = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                        transport.routeSum = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                        result.data.Add(transport);
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
            result.data_name = "transport";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }

        public object Verify(string mobile, string regNo)
        {
            Result result = new Result();
            int getErrCode = -1;
            string query = string.Format(@"[VerifyDriver] @Mobile='{0}' ,@regNo='{1}'", mobile, regNo);
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {                   
                    while (reader.Read())
                    {
                        getErrCode = (reader.GetValue(0) != null) ? reader.GetInt32(0) : 0;
                        if (getErrCode > 0)
                        {
                            Transport transport = new Transport();
                            transport.vehID = (reader.GetValue(0) != null) ? reader.GetInt32(0) : 0;
                            transport.sNo = "NA";
                            transport.regNo = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                            transport.vehType = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                            transport.driverName = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                            transport.phoneNo = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                            transport.alternativeNo = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                            transport.routeSum = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                            result.data.Add(transport);
                            result.message = "Login Successfully!";
                            result.status = 1;
                            result.count = result.data.Count;
                        }
                        else
                        {
                            result.status = 0;
                            result.count = 0;
                            result.message = "No User Found With These Credentials!";
                        }
                    }
                }
                else
                {
                    result.status = 0;
                    result.count = 0;
                    result.message = "No Data Found";
                }
                con.Close();
            }
            
            result.data_name = "driver_verification";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
    }
}