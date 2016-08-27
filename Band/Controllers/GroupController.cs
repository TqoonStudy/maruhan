using Band.Service;
using JangBoGo.Info.Object;
using JangBoGo.Info.Object.ObjectHelper;
using JangBoGo.Utils;
using JangBoGo.Web;
using Models.Group.Model;
using Models.Group.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Band.Controllers
{
    public class GroupController : AbstractController
    {
        GroupService groupService = new GroupService();

        public ActionResult getListByUserId(int userId)
        {
            //var list = groupService.getListByUserid(userId);
            var list = COD.FindList<GroupItem>($@"SELECT *
                                                                        FROM [Group] a
                                                                        WHERE a.userid = { userId}");
            return Json(list);
        }

        public ActionResult Board()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Insert(string groupname, string img, string colorCode,int userid)
        {
            GroupItem group = new GroupItem();
            group.Groupname = groupname;
            group.Img = img;
            group.ColorCode = colorCode;
            group.UserId = userid;
            int result = groupService.insert(group);

            try
            {
                return Json(new { result="success",index = result },JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result="fail",message=e.Message },JsonRequestBehavior.AllowGet);
            }
        }

    }
}