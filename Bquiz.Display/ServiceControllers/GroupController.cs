using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BquizDB.Business;
using Bquiz.Display.ServiceModels;

namespace Bquiz.Display.ServiceControllers
{
    public class GroupController : ApiController
    {
        //Get //api/group
        [HttpGet]
        public List<Group> Get(byte partNumber, int lastSync = 0)
        {
            bl_QuestionGroup bl_group = new bl_QuestionGroup();
            bl_Question bl_question = new bl_Question();

            List<Group> data = bl_group.GetAllPartById(partNumber)
                .Where(m => m.SyncVersion > lastSync)
                .Select(m => new Group(m))
                .ToList();

            foreach (var item in data)
            {
                item.Questions = bl_question.GetByGroupId(item.GroupId)
                    .Select(m => new Question(m))
                    .ToList();
            }

            return data;
        }

        // GET api/group/get
        [HttpGet]
        public IEnumerable<string> GetData()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
