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
using Band.Dao;

namespace Band.Service
{
    public class GroupService
    {
        GroupDao dao = new GroupDao();

        public IList<GroupItem> getListByUserid(int userId)
        {
            IList<GroupItem> result = new List<GroupItem>();

            try
            {
                result = dao.getListByUserid(userId);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public int InsertGroup(GroupItem group)
        {
            int result = 0;
            try
            {
                 result = dao.InsertGroup(group);
            }
            catch (Exception e) { throw e; }

            return result;
        }

        public int insert(GroupItem item)
        {
            int result = 0;
            try
            {
                result = dao.insert(item);
            }
            catch (Exception e) { throw e; }

            return result;
        }
    }
}