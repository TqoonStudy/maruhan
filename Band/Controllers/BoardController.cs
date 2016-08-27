using Models.Board.Model;
using Models.Group.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Band.Controllers
{
    public class BoardController : AbstractController
    {

        public ActionResult List(int groupId)
        {
            IList<BoardItem> board = new List<BoardItem>();
            GroupItem group;

            try
            {
                group = COD.FindItem<GroupItem>($@"SELECT *
                                                                                            FROM [Group]
                                                                                            WHERE id = {groupId}");
            }
            catch (Exception e)
            {
                throw e;
            }

            return View(group);
        }

        public void Write(BoardItem board)
        {
            try
            {
                COD.Insert(board);
            }catch(Exception e)
            {
                throw e;
            }

        }

    }
}