using JangBoGo.Info.Object;
using JangBoGo.Info.Object.ObjectHelper;
using JangBoGo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Band.Controllers
{
    public abstract class AbstractController : Controller
    {
        [Autowire]
        public ICommonObjectDao COD { get; set; }

        public AbstractController()
        {
            SpringAutowire.Autowire(this);
        }
    }
}