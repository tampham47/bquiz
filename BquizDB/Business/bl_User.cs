using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BquizDB.Entities;

namespace BquizDB.Business
{
    public class bl_User
    {
        BquizEntities db = new BquizEntities();
        public bl_User(BquizEntities connection = null)
        {
            if (connection != null)
            {
                db = connection;
            }
        }

        public int Create(Guid userId, string userName, string email, bool gender, DateTime birthday)
        {
            var result = (int)db.qz_User_Create(
                userId, userName,
                email, gender, birthday).Single();

            return result;
        }
        public bq_User GetById(Guid userId)
        {
            var result = db.qz_User_GetById(userId).ToList();

            if (result.Count > 0)
                return result.First();
            else
                return null;
        }
        public bq_User GetByUserName(string userName)
        {
            var result = (
                from get in db.bq_User
                where get.UserName == userName
                select get
                ).ToList();

            if (result.Count <= 0)
                return null;
            else
                return result.First();
        }
        public List<bq_User> GetAll()
        {
            return db.bq_User.ToList();
        }
        public List<bq_User> GetTop(int top)
        {
            return db.qz_User_GetTop(top).ToList();
        }
        public int GetRanking(int bestScore)
        {
            var result = (int)db.qz_User_GetRanking(bestScore).Single();
            return result;
        }

        public int Update(Guid userId, string userName, string email, bool? gender, DateTime? birthday)
        {
            var result = (int)db.qz_User_Update(
                userId, userName, gender, birthday).Single();

            return result;
        }
        public int UpdateAvatar(Guid userId, string avatarPath)
        {
            var result = (int)db.qz_User_UpdateAvatar(
                userId, avatarPath).Single();

            return result;
        }
        public int UpdateBestScore(Guid userId, int bestScore)
        {
            var result = (int)db.qz_User_UpdateBestScore(
                userId, bestScore).Single();

            return result;
        }
    }
}
