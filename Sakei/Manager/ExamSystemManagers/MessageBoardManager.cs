using Sakei.Models.ExamSystemModels;
using SaKei.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sakei.Manager.ExamSystemManagers
{
    public class MessageBoardManager
    {
        #region 增修查
        ///<summary>查詢單題留言板(將資料從DB取出)</summary>
        public List<MessageBoardModel> GetMessageBoardList(Guid testID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT 
                                	MessageID,
                                	TestID,
                                	MessageBoards.UserID,
                                	UserName,
                                	UserLevel,
                                	MessageContent,
                                	MessageBoards.CreateDate
                                FROM (MessageBoards
                                INNER JOIN [UserAccounts] 
                                ON MessageBoards.UserID=UserAccounts.UserID)
                                INNER JOIN [User]
                                ON MessageBoards.UserID=[User].UserID
                                WHERE TestID = @TestID
                                ORDER BY MessageBoards.CreateDate DESC
                                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@TestID", testID);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        List<MessageBoardModel> messageBoardList = new List<MessageBoardModel>();
                        //將資料取出放到List中
                        while (reader.Read())
                        {
                            MessageBoardModel info = new MessageBoardModel
                            {
                                MessageID=(Guid)reader["MessageID"],
                                UserID = (Guid)reader["UserID"],
                                UserName=reader["UserName"] as string,
                                UserLevel=(int)reader["UserLevel"],
                                TestID = (Guid)reader["TestID"],
                                MessageContent = reader["MessageContent"] as string,
                                CreateDate = (DateTime)reader["CreateDate"]
                            };
                            messageBoardList.Add(info);
                        }
                        return messageBoardList;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.MessageBoardManager.GetMessageBoardList", ex);
                throw;
            }
        }

        ///<summary>增加使用者留言</summary> 
        public void CreateMessage(MessageBoardModel model)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                INSERT INTO MessageBoards
                                ( UserID, TestID, MessageContent)
                                VALUES
                                ( @UserID, @TestID, @MessageContent)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", model.UserID);
                        command.Parameters.AddWithValue("@TestID", model.TestID);
                        command.Parameters.AddWithValue("@MessageContent", model.MessageContent);
                        conn.Open();
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.MessageBoardManager.CreateMessage", ex);
                throw;
            }
        }
       
        #endregion
    }
}