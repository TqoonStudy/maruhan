using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Models.File.Model;

namespace Band.Dao
{
    public class FileDao :AbstractDao<FileItem>
    {
        public FileDao(){

        }
        public string getBandImg(int fileid)
        {
            string result = "";
            string query = "select * from [file] where id = "+fileid;

            SqlConnection con = new SqlConnection();
            con.ConnectionString= "SERVER=192.168.1.76;DATABASE=StudyBand;USER ID=sa; PASSWORD=ad!@#0";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            return result;
        }

    }
}