﻿using Sakei.Models;
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
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.UserAnswerManager.GetUserAnswer", ex);
                throw;
            }
        }
        public List<ShoppingListModel> GetShoppingList(Guid UserID)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM [ShoppingLists]
                    WHERE UserID = @UserID";
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
                                Content = reader["ItemContent"] as string,
                                CreateDate = (DateTime)reader["CreateDate"],
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
        public List<ShoppingListModel> GetShoppingList(Guid userID, List<Guid> shoppingID)
        {
            //判斷有傳入ID
            if (shoppingID == null || shoppingID.Count == 0)
                throw new Exception("沒有 ShoppingID");

            //組合要搜尋的ShoppingID資料
            List<string> param = new List<string>();
            for (var i = 0; i < shoppingID.Count; i++)
            {
                param.Add("@ShoppingID" + i);
            }
            string inSql = string.Join(", ", param);

            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                SELECT *
                                FROM ShoppingLists
                                WHERE UserID = @UserID AND
                                      ShoppingID IN ({inSql})
                                ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        for (var i = 0; i < shoppingID.Count; i++)
                        {
                            command.Parameters.AddWithValue("@ShoppingID" + i, shoppingID[i]);

                        }
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        List<ShoppingListModel> shoppingList = new List<ShoppingListModel>();
                        while (reader.Read())
                        {
                            ShoppingListModel model = new ShoppingListModel()
                            {
                                ID = (Guid)reader["ShoppingID"],
                                UserID = userID,
                                ItemID = (Guid)reader["ItemID"],
                                Content = reader["ItemContent"] as string,
                                CreateDate = (DateTime)reader["CreateDate"],
                            };
                            shoppingList.Add(model);
                        };

                        return shoppingList;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Sakei.Manager.TestSystemManagers.ShoppingListManager.GetShoppingList", ex);
                throw;
            }
        }       
        ///<summary>增加單使用者作答紀錄資料</summary> 
        private static void CreateShoppingList(ShoppingListModel model)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText = $@"
                                INSERT INTO ShoppingLists
                                ( UserID, ShoppingID, ItemID, ItemContent, CreateDate)
                                VALUES
                                ( @UserID, @ShoppingID, @ItemID, @ItemContent ,@CreateDate)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@ShoppingID", model.ID);
                        command.Parameters.AddWithValue("@UserID", model.UserID);
                        command.Parameters.AddWithValue("@ItemID", model.ItemID);
                        command.Parameters.AddWithValue("@ItemContent", model.Content);
                        command.Parameters.AddWithValue("@CreateDate", model.CreateDate);

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