using SchoolAPI.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Fee
{
    public class FeeRepository : IFeeInterface
    {
        SqlConnection con;
        public FeeRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }

        public Object GetUpdate(string sno)
        {
            Result result = new Result();
            string query = string.Format(@"InUpDeSeFee @StatementType ='Get',@s_no ='" + sno + "'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Fee fee = new Fee();
                        fee.sNo = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        fee.classCurrent = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        fee.PaySlipNo = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        fee.Session = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        fee.Date = (reader.GetValue(4) != null) ? reader.GetString(4) : "NA";
                        fee.TermFor = (reader.GetValue(5) != null) ? reader.GetString(5) : "NA";
                        fee.Discount = (reader.GetValue(6) != null) ? reader.GetString(6) : "NA";
                        fee.PaymentMode = (reader.GetValue(7) != null) ? reader.GetString(7) : "NA";
                        fee.NetFee = (reader.GetValue(8) != null) ? reader.GetString(8) : "NA";
                        fee.Fine = (reader.GetValue(9) != null) ? reader.GetString(9) : "NA";
                        fee.Comment = (reader.GetValue(10) != null) ? reader.GetString(10) : "NA";
                        fee.MiscFee = (reader.GetValue(11) != null) ? reader.GetString(11) : "NA";
                        fee.TCFee = (reader.GetValue(12) != null) ? reader.GetString(12) : "NA";
                        fee.AdmissionFee = (reader.GetValue(13) != null) ? reader.GetString(13) : "NA";
                        fee.TuitionFee = (reader.GetValue(14) != null) ? reader.GetString(14) : "NA";
                        fee.CautionFee = (reader.GetValue(15) != null) ? reader.GetString(15) : "NA";
                        fee.AnnualFee = (reader.GetValue(16) != null) ? reader.GetString(16) : "NA";
                        result.data.Add(fee);
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
            result.data_name = "fee";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }

        public Object GetInstallments(string sno)
        {
            Result result = new Result();
            string query = string.Format(@"InUpDeSeFee @StatementType ='GetAllFeeByClass',@s_no ='" + sno + "'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        Installments installments = new Installments();
                        installments.FeeName = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        installments.Term = (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        installments.ForNewStudent = (reader.GetValue(2) != null) ? reader.GetString(2) : "NA";
                        installments.ForOldStudent = (reader.GetValue(3) != null) ? reader.GetString(3) : "NA";
                        
                        result.data.Add(installments);
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
            result.data_name = "installments";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
    }
}