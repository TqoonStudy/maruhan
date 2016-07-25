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
            var list = COD.FindList<GroupItem>("select * from [Group] a where a.id IN(select groupid from GroupMember where userid = " + userId + ")");
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

        public ActionResult Insert()
        {
            try
            {
                return Json(new { result="success" },JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result="fail",message=e.Message },JsonRequestBehavior.AllowGet);
            }
        }

    }
}