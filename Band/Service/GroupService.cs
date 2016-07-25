using System;
using System.Collections.Generic;
using Models.Group.Model;
using Models.Group.Query;
using JangBoGo.Info.Object;
using JangBoGo.Info.Object.ObjectHelper;
using System.Web.Mvc;
using JangBoGo.Utils;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Band.Service
{
    public class GroupService
    {
        public IList<GroupItem> getListByUserid(int userId)
        {
            IList<GroupItem> result = new List<GroupItem>();

            string sqlQuery = "select * from[Group] a where a.id IN (select groupid from GroupMember where userid = "+ userId + "); ";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "SERVER=192.168.1.76;DATABASE=StudyBand;USER ID=sa; PASSWORD=ad!@#0";
                con.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery,con);

                SqlDataReader reader = cmd.ExecuteReader();

                Trace.WriteLine(reader.Read());

                while (reader.Read()) {

                    GroupItem item = new GroupItem();
                    item.Id = (int)reader.GetValue(0);
                    item.Groupname = (string)reader.GetValue(1);
                    item.Img = (int)reader.GetValue(2);
                    item.Groupinfo = (string) reader.GetValue(3);
                    item.Regdate = (DateTime)reader.GetValue(4);
                    for (int i = 0; i < 5; i++)
                    {
                        Trace.WriteLine(reader.GetValue(i));
                    }
                    result.Add(item);
                }



            } catch(Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}