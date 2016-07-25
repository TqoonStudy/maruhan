using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JangBoGo.Info.Object;
namespace Models.Group.Query
{
    public static class GroupQuery
    {
        public static ListQuery<Models.Group.Model.GroupItem> FindByUserId(int userId)
        {
            return new ListQuery<Group.Model.GroupItem>("select * from Group where userid = "+userId);
        }
    }
}
