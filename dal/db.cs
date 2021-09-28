using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SchoolAPI.dal
{
    public class db
    {
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter ad;
        int Result = 0;
        SqlConnection con;

        public int OrderNotificationPortal(Boolean notification)
        {
            try
            {
                cmd = new SqlCommand("InUpDeSeNotification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StatementType", "UpNotification");
                cmd.Parameters.AddWithValue("@NotificationValue", notification);
                cmd.Parameters.AddWithValue("@NotificationType", "OrderPortal");
                cmd.Parameters.AddWithValue("@SystemType", 1001);

                var returnParameter = cmd.Parameters.Add("@ErrorCode", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                con.Open();
                Result = cmd.ExecuteNonQuery();
                int isExist = (int)cmd.Parameters["@ErrorCode"].Value;
                //var isExist = returnParameter.Value;
                con.Close();

                if (Result != 1 && isExist == -101)
                {
                    return isExist; // Executed Success & Exist -- 101
                }
                if (Result != 1 && isExist >= 1)
                {
                    //AddUserData(user);
                    return isExist; // Executed Success -- return productID
                }
                if (Result == 1 && isExist >= 0)
                {
                    return isExist; // Executed Success -- return productID
                }
                else
                {
                    return Result; // Executed Failed -- 0
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataSet GetNotificationForUser()
        {
            return SelectDataset("InUpDeSeNotification @StatementType='Se',@NotificationType='OrderPortal'");
        }

        #region General
        public db()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }
        public DataTable SelectDatasTable(string column, string table, int id)
        {
            string qry = "";
            if (id == 0)
            {
                qry = "SELECT " + column + " FROM " + table;
            }
            else if (id != 0)
            {
                qry = "SELECT " + column + " FROM " + table + " Where ID=" + id;
            }
            ad = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public DataSet SelectDataset(string column, string table, int id)
        {
            string qry = "";
            if (id == 0)
            {
                qry = "SELECT " + column + " FROM " + table;
            }
            else if (id != 0)
            {
                qry = "SELECT " + column + " FROM " + table + " Where CreatedBy=" + id;
            }
            ad = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            ad.Fill(dt);

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);


            return ds;
        }
        public DataSet SelectDataset(string Qry)
        {
            if (Qry != null)
            {
                ad = new SqlDataAdapter(Qry, con);
                dt = new DataTable();
                ad.Fill(dt);

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);


                return ds;
            }
            else
                return null;
           
        }
        public DataSet CustomeDataset(string column, string table, string condition)
        {
            string qry = "";
            if (column != "" || table != "" || condition != "")
            {
                qry = "SELECT " + column + " FROM " + table + " WHERE " + condition;
            }
            ad = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            ad.Fill(dt);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
        public DataSet CustomeQryDataset(string Qry, Dictionary<String, Object> parameters)
        {
            cmd = new SqlCommand(Qry, con);
            //cmd.CommandText = Qry;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;

            foreach (KeyValuePair<String, Object> p in parameters)
            {
                //cmd.Parameters.AddWithValue("@" + p.Key.ToString(),  p.Value );
                param = new SqlParameter();
                param.ParameterName = "@" + p.Key.ToString();
                param.Value = p.Value.ToString();
                cmd.Parameters.Add(param);
            }

            ad = new SqlDataAdapter(cmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(ad);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            //con.Open();
            //ad = new SqlDataAdapter(cmd);
            //dt = new DataTable();
            //ad.Fill(dt);
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);

            con.Close();
            return ds;
        }
        #endregion

        //#region USER
        //public int AddUser(User user)
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("InUpDeSeLogin", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id", 0);
        //        cmd.Parameters.AddWithValue("@Code", user.CODE);
        //        cmd.Parameters.AddWithValue("@Num", user.NUM);
        //        cmd.Parameters.AddWithValue("@Email", ((user.Email).ToLower()).Trim());
        //        cmd.Parameters.AddWithValue("@Key", user.Key);
        //        cmd.Parameters.AddWithValue("@ApiAuthentication", user.API);
        //        cmd.Parameters.AddWithValue("@Mobile", user.Mobile);
        //        cmd.Parameters.AddWithValue("@Name", user.Name);
        //        cmd.Parameters.AddWithValue("@Columns", "");
        //        cmd.Parameters.AddWithValue("@SystemType", user.SystemType);
        //        cmd.Parameters.AddWithValue("@UserType", user.UserType);
        //        cmd.Parameters.AddWithValue("@StatementType", "In");

        //        var returnParameter = cmd.Parameters.Add("@ErrorCode", SqlDbType.Int);
        //        returnParameter.Direction = ParameterDirection.ReturnValue;
        //        con.Open();
        //        Result = cmd.ExecuteNonQuery();
        //        int isExist = (int)cmd.Parameters["@ErrorCode"].Value;
        //        //var isExist = returnParameter.Value;
        //        con.Close();

        //        if (Result != 1 && isExist == -101)
        //        {
        //            return isExist; // Executed Success & Exist -- 101
        //        }
        //        if (Result != 1 && isExist == 1)
        //        {
        //            //AddUserData(user);
        //            return isExist; // Executed Success -- 1
        //        }
        //        else
        //        {
        //            return Result; // Executed Failed -- 0
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //public int VerifyUser(User user)
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("VerifyUser", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Useremail", user.Email);
        //        cmd.Parameters.AddWithValue("@Password", user.Key);
        //        con.Open();
        //        Result = Convert.ToInt32(cmd.ExecuteScalar());
        //        con.Close();

        //        return Result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //public Object getVerifyUser(int ID)
        //{
        //    List<User> users = new List<User>();
        //    List<Result> Result = new List<Result>();
        //    Result result = new Result();
        //    string query = string.Format(@"SELECT tblUsers.Num, tblUsers.Code, tblUsers.Name, tblUsers.Email, tblUsers.Mobile,tblLogin.ID FROM tblLogin INNER JOIN tblUsers ON tblLogin.Num = tblUsers.Num Where  tblLogin.ID = " + ID);
        //    using (SqlCommand cmd = new SqlCommand(query, con))
        //    {
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            result.message = "Data Found";
        //            while (reader.Read())
        //            {
        //                User user = new User();
        //                user.NUM = (reader.GetValue(0) != null) ? int.Parse(reader.GetString(0)) : 0;
        //                user.CODE = (reader.GetValue(1) != null) ? reader.GetString(1) : string.Empty;
        //                user.Name = (reader.GetValue(2) != null) ? reader.GetString(2) : string.Empty;
        //                user.Email = (reader.GetValue(3) != null) ? reader.GetString(3) : string.Empty;
        //                user.Mobile = (reader.GetValue(4) != null) ? reader.GetString(4) : string.Empty;
        //                //user.LoginID = (reader.GetValue(5) != null) ? (reader.GetInt32(5)) : 0;
        //                //categories.Add(category);
        //                result.data.Add(user);
        //            }
        //        }
        //        else
        //        {
        //            result.message = "No Data Found";
        //        }
        //        con.Close();
        //    }
        //    result.status = 1;
        //    result.count = result.data.Count;
        //    result.data_name = "User";
        //    result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
        //    return result;            
        //}
        //public int AddUserData(User user)
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("InUpDeSeUser", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id", 0);
        //        cmd.Parameters.AddWithValue("@Code", user.CODE);
        //        cmd.Parameters.AddWithValue("@Num", user.NUM);
        //        cmd.Parameters.AddWithValue("@ApiAuthentication", user.API);
        //        cmd.Parameters.AddWithValue("@Name", "");
        //        cmd.Parameters.AddWithValue("@Address1", "");
        //        cmd.Parameters.AddWithValue("@Address2", "");
        //        cmd.Parameters.AddWithValue("@City", "");
        //        cmd.Parameters.AddWithValue("@Mobile", user.Mobile);
        //        cmd.Parameters.AddWithValue("@Email", user.Email);
        //        cmd.Parameters.AddWithValue("@CreatedBy", 0);
        //        cmd.Parameters.AddWithValue("@ModifiedBy", 0);
        //        cmd.Parameters.AddWithValue("@Columns", "");
        //        cmd.Parameters.AddWithValue("@StatementType", "In");
        //        var returnParameter = cmd.Parameters.Add("@ErrorCode", SqlDbType.Int);
        //        returnParameter.Direction = ParameterDirection.ReturnValue;
        //        con.Open();
        //        Result = cmd.ExecuteNonQuery();
        //        int isExist = (int)cmd.Parameters["@ErrorCode"].Value;
        //        //var isExist = returnParameter.Value;
        //        con.Close();

        //        if (Result != 1 && isExist == 101)
        //        {
        //            return isExist; // Executed Success & Exist -- 101
        //        }
        //        if (Result != 1 && isExist == 1)
        //        {
        //            return isExist; // Executed Success -- 1
        //        }
        //        else
        //        {
        //            return Result; // Executed Failed -- 0
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //public int UpdateUserActive(User UserRow)
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("InUpDeSeLogin", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@StatementType", "UpActive");
        //        cmd.Parameters.AddWithValue("@NUM", UserRow.NUM);
        //        cmd.Parameters.AddWithValue("@CODE", UserRow.CODE);
        //        cmd.Parameters.AddWithValue("@Columns", UserRow.isActive);

        //        var returnParameter = cmd.Parameters.Add("@ErrorCode", SqlDbType.Int);
        //        returnParameter.Direction = ParameterDirection.ReturnValue;
        //        con.Open();
        //        Result = cmd.ExecuteNonQuery();
        //        int isExist = (int)cmd.Parameters["@ErrorCode"].Value;
        //        //var isExist = returnParameter.Value;
        //        con.Close();

        //        if (Result != 1 && isExist == -101)
        //        {
        //            return isExist; // Executed Success & Exist -- 101
        //        }
        //        if (Result != 1 && isExist == 1)
        //        {
        //            //AddUserData(user);
        //            return isExist; // Executed Success -- 1
        //        }
        //        else
        //        {
        //            return Result; // Executed Failed -- 0
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //public int UpdateChangePwd(User PwdRow)
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("InUpDeSeLogin", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@StatementType", "UpPwd");
        //        cmd.Parameters.AddWithValue("@NUM", PwdRow.NUM);
        //        cmd.Parameters.AddWithValue("@CODE", PwdRow.CODE);
        //        cmd.Parameters.AddWithValue("@Key", PwdRow.Key);

        //        var returnParameter = cmd.Parameters.Add("@ErrorCode", SqlDbType.Int);
        //        returnParameter.Direction = ParameterDirection.ReturnValue;
        //        con.Open();
        //        Result = cmd.ExecuteNonQuery();
        //        int isExist = (int)cmd.Parameters["@ErrorCode"].Value;
        //        //var isExist = returnParameter.Value;
        //        con.Close();

        //        if (Result != 1 && isExist == -101)
        //        {
        //            return isExist; // Executed Success & Exist -- 101
        //        }
        //        if (Result != 1 && isExist == 1)
        //        {
        //            //AddUserData(user);
        //            return isExist; // Executed Success -- 1
        //        }
        //        else
        //        {
        //            return Result; // Executed Failed -- 0
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //#endregion

        //#region Company
        //public int SaveCompany(Company company)
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("InUpDeSeCompany", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@StatementType", "InUp");
        //        cmd.Parameters.AddWithValue("@id", company.id);
        //        cmd.Parameters.AddWithValue("@Columns", "");
        //        cmd.Parameters.AddWithValue("@Name", ((company.Name)).Trim());
        //        cmd.Parameters.AddWithValue("@Logo", (company.Logo).Trim());
        //        cmd.Parameters.AddWithValue("@CreatedBy", company.CreatedBy);
        //        cmd.Parameters.AddWithValue("@ModifiedOn", company.CreatedOn);

        //        var returnParameter = cmd.Parameters.Add("@ErrorCode", SqlDbType.Int);
        //        returnParameter.Direction = ParameterDirection.ReturnValue;
        //        con.Open();
        //        Result = cmd.ExecuteNonQuery();
        //        int isExist = (int)cmd.Parameters["@ErrorCode"].Value;
        //        //var isExist = returnParameter.Value;
        //        con.Close();

        //        if (Result != 1 && isExist == -101)
        //        {
        //            return isExist; // Executed Success & Exist -- 101
        //        }
        //        if (Result != 1 && isExist >= 1)
        //        {
        //            //AddUserData(user);
        //            return isExist; // Executed Success -- return productID
        //        }
        //        if (Result == 1 && isExist >= 0)
        //        {
        //            return isExist; // Executed Success -- return productID
        //        }
        //        else
        //        {
        //            return Result; // Executed Failed -- 0
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        //#endregion
    }
}