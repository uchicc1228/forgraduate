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
        public UserModel GetUserName(Guid id)
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
                        ON [UserAccounts].UserID=[User].UserID ";
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
        #endregion
    }
}