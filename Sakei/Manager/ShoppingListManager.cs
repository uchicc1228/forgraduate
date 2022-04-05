using Sakei.Models;
using SaKei.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sakei.Manager
{
    public class ShoppingListManager
    {
        #region 增修查
        ///<summary>查詢單使用者資料(將資料從DB取出)</summary>
        public ShoppingListModel GetShoppingList(Guid userID, Guid shoppingID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT *
                                FROM ShoppingLists
                                WHERE UserID = @UserID AND
                                      ShoppingID = @ShoppingID
                                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@ShoppingID", shoppingID);
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ShoppingListModel model = new ShoppingListModel()
                            {
                                ID = shoppingID,
                                UserID = userID,
                                ItemID = (Guid)reader["ItemID"],
                                Content = reader["ItemContent"] as string,
                                CreateDate = (DateTime)reader["CreateDate"],
                            };
                            return model;
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.ShoppingListManager.GetShoppingList", ex);
                throw;
            }
        }       
        /// <summary>查詢資料庫，以已經購買的商品等級排序</summary>
        public List<ShoppingListModel> GetShoppingList(Guid UserID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT  [ShoppingLists].UserID
	                       ,[ShoppingLists].ItemID
	                       ,[ShoppingLists].ItemContent
	                       ,[ShoppingLists].ShoppingID 
	                       ,ItemLevel
                        FROM [ShoppingLists]
                        INNER JOIN [Malls]
                        ON [ShoppingLists].ItemID=[Malls].ItemID
	                    ORDER BY ItemLevel";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        List<ShoppingListModel> items = new List<ShoppingListModel>();
                        while (reader.Read())
                        {
                            ShoppingListModel model = new ShoppingListModel()
                            {
                                ID = (Guid)reader["ShoppingID"],
                                UserID = (Guid)reader["UserID"],
                                ItemID = (Guid)reader["ItemID"],
                                ItemLevel = (int)reader["ItemLevel"],
                                Content = reader["ItemContent"] as string,
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
        public ShoppingListModel GetShoppingList_shoppingID(Guid userID,Guid itemID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT ShoppingID
                                FROM [ShoppingLists]
                                LEFT JOIN [Malls]
                                ON Malls.ItemID=ShoppingLists.ItemID
                                WHERE ShoppingLists.ItemID=@itemID AND
                                UserID=@userID
                                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@userID", userID);
                        command.Parameters.AddWithValue("@itemID", itemID);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ShoppingListModel shoppingID = new ShoppingListModel()
                            {
                                ID = (Guid)reader["ShoppingID"],
                            };
                            return shoppingID;
                        };

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.ShoppingListManager.GetShoppingList", ex);
                throw;
            }
        }
        ///<summary>增加使用者購買衣服資料</summary> 
        public void CreateShoppingList(ShoppingListModel model)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                INSERT INTO ShoppingLists
                                ( UserID, ItemID, ItemContent)
                                VALUES
                                ( @UserID, @ItemID, @ItemContent)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {

                        command.Parameters.AddWithValue("@UserID", model.UserID);
                        command.Parameters.AddWithValue("@ItemID", model.ItemID);
                        command.Parameters.AddWithValue("@ItemContent", model.Content);

                        conn.Open();
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.ShoppingListManager.CreateShoppingList", ex);
                throw;
            }
        }       
        #endregion
    }
}