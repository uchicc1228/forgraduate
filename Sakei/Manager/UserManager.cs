using SaKei.Helpers;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sakei.Manager
{
    public class UserManager
    {
        #region "抓出帳號名字"
        public UserModel GetUserData(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT 
                        [UserAccounts].UserID
                       ,[UserName]
                       ,[Character]
                       ,[UserLevel] 
                       ,[UserPoints]
                       ,[UserMoney]
                    FROM [UserAccounts]
                    INNER JOIN [User]
                    ON [UserAccounts].UserID=[User].UserID
                    WHERE [UserAccounts].UserID=@id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            UserModel model = new UserModel()
                            {
                                UserMoney = (int)reader["UserMoney"],
                                UserPoints = (int)reader["UserPoints"],
                                UserLevel = (int)reader["UserLevel"],
                                Character = reader["Character"] as string,
                                UserName = reader["UserName"] as string,
                                ID = (Guid)reader["UserID"]
                            };
                            
                            return model;

                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("", ex);
                throw;
            }
        }
        public UserModel GetUserMoney(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT [UserMoney]
                    FROM [UserAccounts]    
                    WHERE UserID=@id                  
                     ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            UserModel model = new UserModel()
                            {
                                UserMoney = (int)reader["UserMoney"],
                            };
                            return model;

                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("", ex);
                throw;
            }
        }
        #endregion

        #region "更新名字、頭像"
        public void UpdateUserName(UserModel model)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  UPDATE [User]
                    SET 
                        UserName=@name
                    WHERE
                        UserID = @id ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", model.ID);
                        command.Parameters.AddWithValue("@name", model.UserName);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("UpdateUserName", ex);
                throw;
            }
        }
        public void UpdateCharacter(Guid userID,Guid itemID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  UPDATE [User]
                    SET 
                        [Character]=(SELECT [StyleContent]
                        FROM Malls
                        WHERE ItemID=@itemID),
                    	ItemID=@itemID
                    WHERE
                        UserID = @id ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@id", userID);
                        command.Parameters.AddWithValue("@itemID", itemID);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("UpdateCharacter", ex);
                throw;
            }
        }        
        #endregion
    }
}