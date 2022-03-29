using SaKei.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaKei.Models;
using SaKei.Manager;

namespace Sakei
{
    public partial class EditItem : System.Web.UI.Page
    {
        ItemModel modelItem = new ItemModel();
        FileManager _mgr_Item = new FileManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //設定item名稱
                modelItem.Name = this.txtItemName.Text.Trim();
                //設定item等級
                modelItem.Level = Convert.ToInt32(this.intLevel.SelectedValue);
                //設定item價格
                modelItem.Price = Convert.ToInt32(this.txtItemPrice.Text);
                //設定item狀態
                modelItem.IsEnable = Convert.ToInt32(this.intEnable.SelectedValue);
                
                //上傳圖片

                if (this.ItemPicUpload.HasFile)
                {
                    this.ltl1.Text = "";
                    string fileName = this.ItemPicUpload.FileName;
                    if (!FileHelper.ValidImageExtension(fileName))
                    {
                        this.ltl1.Text = "必須是 .png檔案格式";
                        return;
                    }
                    string SaveFloderPath = _mgr_Item.GetSavePath();
                    string relativePath = _mgr_Item.GetRelativePath(fileName);
                    string newFileName = System.IO.Path.Combine(SaveFloderPath, fileName);
                    string newFilePath = System.IO.Path.Combine(SaveFloderPath, newFileName);
                    //設定檔案存檔路徑
                    modelItem.Content = relativePath;
                    this.ItemPicUpload.SaveAs(newFileName);

                }
                else
                {
                    this.ltl1.Text = "需上傳檔案";
                }
                //存入資料庫
                _mgr_Item.CreateItem(modelItem);
                Response.Write("<script>alert('新增成功!!')</script>");
                this.ltl1.Text = "";

            }
            catch (Exception ex)
            {
                this.ltl1.Text = "資料錯誤";

            }
           

        }
   
    }
}