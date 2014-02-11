using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BquizDB.Business;
using BquizDB.Entities;
using Bquiz.Services.Models;

namespace Bquiz.Display.ServiceControllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public List<UserProfile> GetAll()
        {
            bl_User blUser = new bl_User();
            var model = blUser.GetAll()
                .Select(m => new UserProfile(m))
                .ToList();

            return model;
        }

        [HttpGet]
        public UserProfile GetById(Guid userId)
        {
            bl_User blUser = new bl_User();
            var model = new UserProfile(blUser.GetById(userId));

            return model;
        }

        [HttpGet]
        public TopModel GetTop(Guid userId, int top = 10)
        {
            bl_User blUser = new bl_User();
            TopModel model = new TopModel();

            model.CurrentUser = new UserProfile(blUser.GetById(userId));
            model.UserList = blUser.GetTop(10)
                .Select(m => new UserProfile(m))
                .ToList();

            return model;
        }

        [HttpGet]
        public TopModel GetTopByZingUser(string userName, int top = 10)
        {
            bl_User blUser = new bl_User();
            TopModel model = new TopModel();

            var user = blUser.GetByUserName("zing." + userName);
            if (user != null)
                model.CurrentUser = new UserProfile(user);
            else
                model.CurrentUser = null;

            model.UserList = blUser.GetTop(10)
                .Select(m => new UserProfile(m))
                .ToList();

            return model;
        }
    }
}
