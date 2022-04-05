using Sakei.Models;
using SaKei.Helpers;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sakei.Manager
{
    public class AdminManager
    {
        #region "抓出帳號名字"
       

        #endregion
        public AdminAccountModel GetAccount(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM AdminAccounts
                    WHERE AdminID = @id ";
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
                            AdminAccountModel model = new AdminAccountModel()
                            {
                                Account = reader["AdminAccount"] as string,
                                Name = reader["AdminName"] as string,
                                Level = (int)reader["AdminLevel"],
                                ID = (Guid)reader["AdminID"]

                            };
                            return model;
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("GetAccount", ex);
                throw;
            }
        }

    }
}
