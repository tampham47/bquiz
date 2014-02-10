using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BquizDB.Business;
using BquizDB.Entities;
//using Bquiz.Display.ServiceModels;

namespace Bquiz.Display.ServiceControllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public List<bq_User> GetAll()
        {
            bl_User blUser = new bl_User();
            var model = blUser.GetAll();

            return model;
        }

        [HttpGet]
        public bq_User GetById(Guid userId)
        {
            bl_User blUser = new bl_User();
            var model = blUser.GetById(userId);

            return model;
        }

        [HttpGet]
        public bl_User GetTop(int top)
        {
            return new bl_User();
        }
    }
}
