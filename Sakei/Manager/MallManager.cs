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
        /// <summary>
        /// 0=全開
        /// 12345=
        /// </summary>
        public List<ItemModel> GetItem(int level)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM [Malls]
                    WHERE ItemLevel = @level AND
                    IsEnable='true'";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@level", level);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        List<ItemModel> items = new List<ItemModel>();
                        while (reader.Read())
                        {
                            ItemModel model = new ItemModel()
                            {
                                ID = (Guid)reader["ItemID"],
                                Level = (int)reader["ItemLevel"],
                                Name = reader["ItemName"] as string,
                                Content = reader["ItemContent"] as string,
                                StyleContent = reader["StyleContent"] as string,
                                Price = (int)reader["ItemPrice"]
                            };
                            items.Add(model);
                        }
                        return items;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("", ex);
                throw;
            }
        }
        public List<ItemModel> GetItem()
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM [Malls]
                    WHERE IsEnable='true'";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        List<ItemModel> items = new List<ItemModel>();
                        while (reader.Read())
                        {
                            ItemModel model = new ItemModel()
                            {
                                ID = (Guid)reader["ItemID"],
                                Level = (int)reader["ItemLevel"],
                                Name = reader["ItemName"] as string,
                                Content = reader["ItemContent"] as string,
                                StyleContent = reader["StyleContent"] as string,
                                Price = (int)reader["ItemPrice"]
                            };
                            items.Add(model);
                        }
                        return items;
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