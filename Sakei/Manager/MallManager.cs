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
    public class MallManager
    {
        #region "抓出道具等級"
        public ItemModel GetItemLevel(int level)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM [Malls]
                    WHERE ItemLevel = @level ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@level", level);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            ItemModel model = new ItemModel()
                            {
                                ID = (Guid)reader["ItemID"],
                                Level = (int)reader["ItemLevel"],
                                Name = reader["ItemName"] as string,
                                Content = reader["ItemContent"] as string,
                                Price = (int)reader["ItemPrice"],
                                IsEnable = (int)reader["IsEnable"]
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