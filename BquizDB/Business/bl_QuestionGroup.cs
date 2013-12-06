using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BquizDB.Entities;

namespace BquizDB.Business
{
    public class bl_QuestionGroup
    {
        BquizEntities db = new BquizEntities();
        public bl_QuestionGroup(BquizEntities connection = null)
        {
            if (connection != null)
            {
                db = connection;
            }
        }

        public Guid Create(Nullable<System.Guid> quizId, Nullable<byte> partId, string name, Nullable<byte> order, string paragraph, string mediaPath)
        {
            var groupId = Guid.NewGuid();
            var result = (int)db.qz_QuestionGroup_Create(
                groupId,
                quizId,
                partId,
                name,
                order,
                paragraph,
                mediaPath).Single();

            if (result > 0)
                return groupId;
            else
                return Guid.Empty;
        }
        public int DeleteByQuizId(Guid quizId)
        {
            var result = (int)db.qz_QuestionGroup_DeleteByQuizId(quizId).Single();

            return result;
        }
        public bq_QuestionGroup GetById(Guid groupId)
        {
            var result = db.qz_QuestionGroup_GetById(groupId).ToList();

            if (result.Count > 0)
                return result.First();
            else
                return null;
        }
        public List<bq_QuestionGroup> GetByQuizId(Guid quizId)
        {
            var result = db.qz_QuestionGroup_GetByQuizId(quizId).ToList();

            return result;
        }
        public List<bq_QuestionGroup> GetByPartId(Guid quizId, byte partId)
        {
            var result = db.qz_QuestionGroup_GetByPartId(
                quizId, partId).ToList();

            return result;
        }

        public int Update(Guid groupId, string paragraph)
        {
            var result = (int)db.qz_QuestionGroup_Update(
                groupId,
                paragraph).Single();

            return result;
        }
        public int UpdateMediaPath(Guid groupId, string mediaPath)
        {
            var result = (int)db.qz_QuestionGroup_UpdateMediaPath(
                groupId,
                mediaPath).Single();

            return result;
        }
        public int UpdateStatus(Guid groupId)
        {
            var result = (int)db.qz_QuestionGroup_UpdateStatus(groupId).Single();

            return result;
        }

        //services
        public List<bq_QuestionGroup> GetAllPartById(byte partId)
        {
            var result = (
                    from get in db.bq_QuestionGroup
                    where
                        get.PartId == partId
                    select get
                ).ToList();

            return result;
        }
    }
}
