using Sakei.Helper;
using Sakei.Models;
using SaKei.Helpers;
using SaKei.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace SaKei.Manager
{
    public class FileManager
    {
        ItemModel model = new ItemModel();
       


        private ItemModel BuildItem(SqlDataReader reader)
        {
            ItemModel model = new ItemModel()
            {
                ID = (Guid)reader["ID"],
                Name = reader["Name"] as string,
                Content = reader["Content"] as string,
                Level = (int)reader["Level"],
                Price = (int)reader["Level"] ,
                IsEnable = (int)reader["Level"]
            };
            return model;
        }
     
        public ItemModel GetItem(string ItemName)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                 @" SELECT *
                    FROM Malls
                    WHERE ItemName = @ItemName";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@ItemName", ItemName);

                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ItemModel model = new ItemModel()
                            {
                                Name = reader["ItemName"] as string,
                                Content = reader["ItemContent"] as string,
                                Price = (int)reader["Price"],
                                ID = (Guid)reader["ItemID"],
                                Level = (int)reader["ItemLevel"],
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
        public ItemModel GetItem(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Malls
                    WHERE ItemID = @id ";
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
                            ItemModel model = new ItemModel()
                            {
                                ID = (Guid)reader["ItemID"],
                                Name = reader["ItemName"] as string,
                                Content = reader["ItemContent"] as string

                            };
                            return model;
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("GetItem", ex);
                throw;
            }
        }
   


        #region "新增"

        public bool CreateItem(ItemModel model)
        {
           

            // 1. 判斷資料庫是否有相同的 Account
            if (this.GetItem(model.Name) != null)

                throw new Exception("道具");

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
               @" INSERT INTO Malls
                        (ItemID, ItemLevel, ItemName ,ItemContent, ItemPrice,IsEnable)
                    VALUES
                        (@id, @level , @name, @Content, @Price,@IsEnable);";



            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        //設定id
                        model.ID = Guid.NewGuid();
                        command.Parameters.AddWithValue("@id", model.ID);
                        command.Parameters.AddWithValue("@level", model.Level);
                        command.Parameters.AddWithValue("@name", model.Name);
                        command.Parameters.AddWithValue("@Content", model.Content);
                        command.Parameters.AddWithValue("@Price", model.Price);
                        command.Parameters.AddWithValue("@IsEnable", model.IsEnable);
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                Logger.WriteLog("CreateItem", ex);
                return false;
            }
        }

        #endregion

        public string GetSavePath() {
        string folder = "~/Images";

            string folderpath = System.Web.Hosting.HostingEnvironment.MapPath(folder);
        return folderpath;
    }
        public string GetRelativePath(string fileNaame)
        {
            string folder = "~/Images";
            fileNaame= folder + "/"+fileNaame;

            return fileNaame;
        }
        public bool ValidFileUpload(System.Web.UI.WebControls.FileUpload fileUpload, out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            // 檢查是否有上傳檔案
            if (!fileUpload.HasFile)
                msgList.Add("需上傳檔案");

            string fileName = fileUpload.FileName;
            // 檢查檔案副檔名是否符合規範
            if (!FileHelper.ValidImageExtension(fileName))
            {
                string fileExts = string.Join(", ", FileHelper.ImageFileExtArr);
                msgList.Add("必須是 " + fileExts + " 檔案格式");
            }

            // 檢查檔案容量是否符合規範
            byte[] fileContent = fileUpload.FileBytes;
            if (!FileHelper.ValidFileLength(fileContent))
            {
                msgList.Add("檔案容量必須是 " + FileHelper.UploadMB + "MB 以內");
            }

            errorMsgList = msgList;
            if (errorMsgList.Count > 0)
                return false;
            else
                return true;
        }



    }



}