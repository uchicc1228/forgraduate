using SaKei.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SaKei.Models;
using SaKei.Manager;

namespace Sakei.Admin
{
    public partial class EditItem : System.Web.UI.Page
    {
        ItemModel modelItem = new ItemModel();
        FileManager _mgr_Item = new FileManager();
        private static int _fileNumber = 1;
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

                ////上傳圖片
                FileUpload[] fuArr = { this.ItemPicUploadMain, this.ItemPicUploadClothes };
                Label[] lblArr = { this.picMainlbl, this.picClotheslbl };
                // 檢查檔案上傳是否正確
                bool isChecked = true;
                for (int i = 0; i < fuArr.Length; i++)
                {
                    this.ltl1.Text = "";
                    FileUpload fu = fuArr[i];
                    Label lbl = lblArr[i];

                    List<string> msgList;
                    if (!FileManager.ValidFileUpload(fu, out msgList))
                    {
                        ltl1.Text = string.Join("<br/>", msgList);
                        isChecked = false;
                    }
                }
                if (!isChecked) // 任何一筆檢查失敗，就停止
                    return;
                for (var i = 0; i < fuArr.Length; i++)
                {
                    FileUpload fu = fuArr[i];
                    string fileName = fu.FileName;


                    if (!FileHelper.ValidImageExtension(fileName))
                    {
                        this.ltl1.Text = "必須是 .png or .jpg 檔案格式";
                        return;
                    }
                }
                    string fileNameMain = fuArr[0].FileName;
                    string fileNameClothes = fuArr[1].FileName;
                    string SaveFloderPathMain = _mgr_Item.GetSavePath();
                    string SaveFloderPathClothes = _mgr_Item.GetSavePath();
                    string relativePathMain = _mgr_Item.GetRelativePath(fileNameMain);
                    string relativePathClothes = _mgr_Item.GetRelativePath(fileNameClothes);
                    string newFileNameMain = System.IO.Path.Combine(SaveFloderPathMain, fileNameMain);
                    string newFileNameClothes = System.IO.Path.Combine(SaveFloderPathClothes, fileNameClothes);
                    string newFilePathMain = System.IO.Path.Combine(SaveFloderPathMain, newFileNameMain);
                    string newFilePathClothes = System.IO.Path.Combine(SaveFloderPathClothes, newFileNameClothes);

              
                    //設定檔案存檔路徑
                    modelItem.Content = relativePathClothes;
                    modelItem.StyleContent = relativePathMain;
                   
               
                    //儲存圖片
                    this.ItemPicUploadClothes.SaveAs(newFileNameClothes);
                    this.ItemPicUploadMain.SaveAs(newFileNameMain);
                this.ltl1.Text = "";
                _mgr_Item.CreateItem(modelItem);
                Response.Write("<script>alert('新增成功!!')</script>");

            }

            catch (Exception ex)
            {
                this.ltl1.Text = "資料錯誤";

            }

        }
    }
}