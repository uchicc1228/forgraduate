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
        public AccountModel GetUserName(string name)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM [User]
                    WHERE UserName = @name ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@account", name);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            AccountModel model = new AccountModel()
                            {
                                Account = reader["UserAccount"] as string,
                                NickName = reader["UserName"] as string,
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


        public AccountModel GetUserName(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM [User]
                    WHERE UserID = @id ";
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
                            AccountModel model = new AccountModel()
                            {

                                NickName = reader["UserName"] as string,
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