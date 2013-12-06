using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BquizDB.Entities;

namespace BquizDB.Business
{
    public class bl_Part
    {
        BquizEntities db = new BquizEntities();
        public bl_Part(BquizEntities connection = null)
        {
            if (connection != null)
            {
                db = connection;
            }
        }

        public List<bq_Part> GetAllChild()
        {
            var result = db.qz_Part_GetAllChilds().ToList();
            return result;
        }
        public bq_Part GetById(byte partId)
        {
            var result = db.qz_Part_GetById(partId).Single();
            return result;
        }
        public List<bq_Part> GetByParentId(byte parentId)
        {
            var result = db.qz_Part_GetByParentId(parentId).ToList();
            return result;
        }
    }
}
