using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BquizDB.Entities;

namespace BquizDB.Business
{
    public class bl_Question
    {
        BquizEntities db = new BquizEntities();
        public bl_Question(BquizEntities connection = null)
        {
            if (connection != null)
            {
                db = connection;
            }
        }

        public bq_Question GetById(Guid questionId)
        {
            var result = db.qz_Question_GetById(questionId).Single();
            return result;
        }
        public List<bq_Question> GetByGroupId(Guid groupId)
        {
            var result = db.qz_Question_GetByQuestionGroupId(groupId).ToList();
            return result;
        }
        public List<bq_Question> GetByQuizId(Guid quizId)
        {
            var result = db.qz_Question_GetByQuizId(quizId).ToList();
            return result;
        }

        public Guid Create(Nullable<System.Guid> questionGroupId, Nullable<System.Guid> quizId, Nullable<byte> order, string imagePath, string mediaPath, string paragraph, string optionA, string optionB, string optionC, string optionD, Nullable<byte> answer)
        {
            var questionId = Guid.NewGuid();
            var result = (int)db.qz_Question_Create(
                questionId,
                questionGroupId,
                quizId,
                order,
                imagePath,
                mediaPath,
                paragraph,
                optionA, optionB, optionC, optionD, answer).Single();
            if (result > 0)
                return questionId;
            else
                return Guid.Empty;
        }
        public int Update(Nullable<System.Guid> questionId, string paragraph, string optionA, string optionB, string optionC, string optionD, Nullable<byte> answer)
        {
            var result = (int)db.qz_Question_Update(
                questionId,
                paragraph,
                optionA, optionB, optionC, optionD, answer).Single();

            return result;
        }
        public int UpdateImagePath(Guid questionId, string imagePath)
        {
            var result = (int)db.qz_Question_UpdateImagePath(
                questionId,
                imagePath).Single();

            return result;
        }
        public int UpdateMediaPath(Guid questionId, string mediaPath)
        {
            var result = (int)db.qz_Question_UpdateMediaPath(
                questionId,
                mediaPath).Single();

            return result;
        }
        public int UpdateStatus(Guid questionId)
        {
            var result = (int)db.qz_Question_UpdateStatus(questionId).Single();

            return result;
        }
        public int DeleteByQuizId(Guid quizId)
        {
            var result = (int)db.qz_Question_DeleteByQuizId(quizId).Single();
            return result;
        }
    }
}
