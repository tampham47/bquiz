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
        public string Get(string userName, string pass)
        {
            return string.Format("Connected get {0} {1}", userName, pass);
        }

        public string Post(string userName, string pass)
        {
            return string.Format("Connected post {0} {1}", userName, pass);
        }

        [HttpGet]
        public bq_User GetAll()
        {
            var model = new bq_User();
            return model;
        }

        [HttpGet]
        public bq_User GetAll2()
        {
            var model = new bq_User();
            return model;
        }

        [HttpGet]
        public bq_User GetAll2(int a)
        {
            var model = new bq_User();
            model.Email = a.ToString();
            return model;
        }

        [HttpGet]
        public bq_User Filter(string request)
        {
            var model = new bq_User();
            model.Email = request;
            return model;
        }
    }
}
