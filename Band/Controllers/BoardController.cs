using Models.Board.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Band.Controllers
{
    public class BoardController : AbstractController
    {

        public ActionResult List(int groupId)
        {
            var list = new Object();

            try
            {
                list = COD.FindList<BoardItem>("select * from Board where groupid = "+groupId);
            }
            catch (Exception e)
            {
                throw e;
            }

            return View(list);
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