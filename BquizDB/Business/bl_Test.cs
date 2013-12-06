using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BquizDB.Entities;

namespace BquizDB.Business
{
    public class bl_Test
    {
        BquizEntities db = new BquizEntities();
        public bl_Test(BquizEntities connection = null)
        {
            if (connection != null)
            {
                db = connection;
            }
        }

        public Guid Create(Guid userId, Guid quizId)
        {
            var testId = Guid.NewGuid();
            var result = (int)db.qz_Test_Create(
                testId,
                userId, quizId).Single();

            if (result > 0)
                return testId;
            else
                return Guid.Empty;
        }
        public int DeleteByQuizId(Guid quizId)
        {
            var result = (int)db.qz_Test_DeleteByQuizId(quizId).Single();

            return result;
        }

        public bq_Test GetById(Guid quizId)
        {
            var result = db.qz_Test_GetById(quizId).ToList();

            if (result.Count > 0)
                return result.First();
            else
                return null;
        }
        public List<bq_Test> GetByUserId(Guid userId)
        {
            var result = db.qz_Test_GetByUserId(userId).ToList();

            return result;
        }
        public List<bq_Test> GetTop10(Guid quizId)
        {
            var result = db.qz_Test_GetTop10(quizId)
                .Take(7)
                .ToList();

            return result;
        }
        
        public int UpdateMark(Guid testId, int mark)
        {
            var result = (int)db.qz_Test_UpdateMark(
                testId, mark).Single();

            return result;
        }
    }
}
