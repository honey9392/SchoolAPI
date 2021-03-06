using SchoolAPI.dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Gallery
{
    public class ImageGalleryRepository : IImageGalleryInterface
    {
        SqlConnection con;
        public ImageGalleryRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            SqlConnection.ClearAllPools();
        }

        public object GetUpdate(string s_no)
        {
            Result result = new Result();
            string query = string.Format(@"GetTypeData @StatementType ='GetGallery'");
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result.message = "Data Found";
                    while (reader.Read())
                    {
                        ImageGallery imageGallery = new ImageGallery();
                        imageGallery.imageName = (reader.GetValue(0) != null) ? reader.GetString(0) : "NA";
                        imageGallery.description =  (reader.GetValue(1) != null) ? reader.GetString(1) : "NA";
                        imageGallery.imagePath = ConfigurationManager.AppSettings["BaseWEBurl"] + ((reader.GetValue(2) != null) ? reader.GetString(2) : "NA").Replace("~", "");
                        result.data.Add(imageGallery);
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
            result.data_name = "imageGallery";
            result.generated_on = Base.getInstance().GetEpochOf(DateTimeOffset.Now.UtcDateTime);
            return result;
        }
    }
}