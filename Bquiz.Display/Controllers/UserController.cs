using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using Bquiz.Display.Models;
using Bquiz.Display.Helpers;
using BquizDB.Business;
using BquizDB.Entities;

namespace Bquiz.Display.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = ps_Membership.GetUser();
            return View(model);
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            var model = ps_Membership.GetUser();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(bq_User user)
        {
            bl_User bl_User = new bl_User();
            bl_User.Update(user.UserId,
                user.UserName,
                user.Email,
                user.Gender,
                user.Birthday);
            
            return View(user);
        }

        [Authorize]
        public ActionResult Myquiz()
        {
            bl_Quiz bl_Quiz = new bl_Quiz();
            var model = bl_Quiz.GetByUserId(ps_Membership.GetUser().UserId);

            return View(model);
        }

        [Authorize]
        public ActionResult History()
        {
            bl_Test bl_test = new bl_Test();
            var model = bl_test.GetByUserId(ps_Membership.GetUser().UserId);

            return View(model);
        }
    }
}
