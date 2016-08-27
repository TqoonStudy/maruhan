using Models.Group.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Band.Dao
{
    public class GroupDao : AbstractDao<GroupItem>
    {
        public IList<GroupItem> getListByUserid(int userId)
        {
            IList<GroupItem> result = new List<GroupItem>();

            string sqlQuery = @"SELECT *
                                           FROM[Group] a
                                           WHERE a.id IN (
                                                    SELECT groupid
                                                    FROM GroupMember
                                                    WHERE userid = " + userId + "); ";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "SERVER=192.168.1.76;DATABASE=StudyBand;USER ID=sa; PASSWORD=ad!@#0";
                con.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    GroupItem item = new GroupItem();
                    item.Id = (int)reader.GetValue(0);
                    item.Groupname = (string)reader.GetValue(1);
                    item.Img = (string)reader.GetValue(2);
                    item.Regdate = (DateTime)reader.GetValue(4);

                    result.Add(item);
                }

                reader.Close();
                con.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public int InsertGroup(GroupItem group)
        {
            string query = @" INSERT INTO [Group] (groupname,img,colorCode,userid) VALUES
                                    (" + group.Groupname + "," + group.Img + "," + group.ColorCode + "," + group.UserId + ") ";
            int result = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "SERVER=192.168.1.76;DATABASE=StudyBand;USER ID=sa; PASSWORD=ad!@#0";
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}