using Sakei.Models.TestSystemModels;
using SaKei.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sakei.Manager.TestSystemManagers
{
    public class MessageBoardManager
    {
        #region 增修查
        ///<summary>查詢單題留言板(將資料從DB取出)</summary>
        public static List<MessageBoardModel> GetMessageBoardList(int testID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT *
                                FROM MessageBoards
                                WHERE TestID = @TestID
                                ORDER BY CreateDate DESC
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
        public static void CreateMessage(MessageBoardModel model)
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