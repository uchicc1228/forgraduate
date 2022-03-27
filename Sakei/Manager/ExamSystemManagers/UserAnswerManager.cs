using Sakei.Models.ExamSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using SaKei.Helpers;

namespace Sakei.Manager.ExamSystemManagers
{
    public class UserAnswerManager
    {

        #region 增修查
        ///<summary>查詢單使用者資料(將資料從DB取出)</summary>
        public UserAnswerModel GetUserAnswer(Guid userID, Guid testID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT *
                                FROM UserAnswers
                                WHERE UserID = @UserID AND
                                      TestID = @TestID
                                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@TestID", testID);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        UserAnswerModel userAnswer = new UserAnswerModel
                        {
                            UserID = userID,
                            TestID = (Guid)reader["TestID"],
                            UserAnswer = reader["UserAnswer"] as string,
                            UserNote = reader["UserNote"] as string,
                            CreateDate = (DateTime)reader["CreateDate"],
                            IsNew = false
                        };

                        return userAnswer;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.UserAnswerManager.GetUserAnswer", ex);
                throw;
            }
        }
        public List<UserAnswerModel> GetUserAnswerList(Guid userID, List<Guid> testIDs)
        {
            //判斷有傳入ID
            if (testIDs == null || testIDs.Count == 0)
                throw new Exception("需指定 testIDs");

            //組合要搜尋的TestID資料
            List<string> param = new List<string>();
            for (var i = 0; i < testIDs.Count; i++)
            {
                param.Add("@TestID" + i);
            }
            string inSql = string.Join(", ", param);

            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT *
                                FROM UserAnswers
                                WHERE UserID = @UserID AND
                                      TestID IN ({inSql})
                                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        for (var i = 0; i < testIDs.Count; i++)
                        {
                            command.Parameters.AddWithValue("@TestID" + i, testIDs[i]);

                        }
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<UserAnswerModel> userAnswer = new List<UserAnswerModel>();
                        while (reader.Read())
                        {
                            UserAnswerModel model = new UserAnswerModel()
                            {
                                UserID = userID,
                                TestID = (Guid)reader["TestID"],
                                UserAnswer = reader["UserAnswer"] as string,
                                UserNote = reader["UserNote"] as string,
                                CreateDate = (DateTime)reader["CreateDate"],
                                IsNew = false
                            };
                            userAnswer.Add(model);
                        };

                        return userAnswer;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.UserAnswerManager.GetUserAnswerList", ex);
                throw;
            }
        }
        ///<summary>儲存並判斷該更新或新增作答紀錄資料</summary>
        public void SaveUserAnswer(UserAnswerModel modelList)
        {
            if (modelList.IsNew)
                CreateUserAnswer(modelList);
            else
                UpdateUserAnswer(modelList);
        }
        ///<summary>增加單使用者作答紀錄資料</summary> 
        private static void CreateUserAnswer(UserAnswerModel model)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                INSERT INTO UserAnswers
                                ( UserID, TestID, UserAnswer, UserNote)
                                VALUES
                                ( @UserID, @TestID, @UserAnswer, @UserNote)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", model.UserID);
                        command.Parameters.AddWithValue("@TestID", model.TestID);
                        command.Parameters.AddWithValue("@UserNote", model.UserNote);
                        command.Parameters.AddWithValue("@UserAnswer", model.UserAnswer);

                        conn.Open();
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.UserAnswerManager.CreateUserAnswer", ex);
                throw;
            }
        }
        ///<summary>修改單使用者作答紀錄資料</summary> 
        private static void UpdateUserAnswer(UserAnswerModel model)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                UPDATE UserAnswers
                                SET
                                    UserAnswer = @UserAnswer,
                                    UserNote = @UserNote
                                WHERE 
                                    UserID = @UserID AND
                                    TestID = @TestID
                                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", model.UserID);
                        command.Parameters.AddWithValue("@TestID", model.TestID);
                        command.Parameters.AddWithValue("@UserNote", model.UserNote);
                        command.Parameters.AddWithValue("@UserAnswer", model.UserAnswer);

                        conn.Open();
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.UserAnswerManager.UpdateUserAnswer", ex);
                throw;
            }
        }
        #endregion
    }
}