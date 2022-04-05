using Sakei.Manager;
using Sakei.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei.Admin
{
    public partial class EditTest : System.Web.UI.Page
    {
        TestModel modelTest = new TestModel();
        TestManager _mgr_Test = new TestManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            bool inputError = false;
            this.ltl1.Text = " ";
            //新增GUID
            modelTest.ID = Guid.NewGuid();
            //新增題目等級
            
            modelTest.Level = Convert.ToInt32(this.intLevel.SelectedValue);
            //新增題目類型
            modelTest.Type = Convert.ToInt32(this.intType.SelectedValue);
            //新增題目內容
            if (this.txtContent.Text == "")
            { this.ltl1.Text += "請輸入題目內容! ";
                inputError = true;
            }
            modelTest.Content = this.txtContent.Text;

            //新增選項內容
            if (this.txtOptionsA.Text == "")
            {
                this.ltl1.Text += "請輸入選項A! ";
                inputError = true;
            }
            modelTest.OptionsA = this.txtOptionsA.Text.Trim();
            if (this.txtOptionsB.Text == "" )
            {
                this.ltl1.Text += "請輸入選項B! ";
                inputError = true;
            }
            modelTest.OptionsB = this.txtOptionsB.Text.Trim();
            if (this.txtOptionsC.Text == "")
            {
                this.ltl1.Text += "請輸入選項C! ";
                inputError = true;
            }
            modelTest.OptionsC = this.txtOptionsC.Text.Trim();
            if (this.txtOptionsD.Text == "")
            {
                this.ltl1.Text += "請輸入選項D! ";
                inputError = true;
            }
            modelTest.OptionsD = this.txtOptionsD.Text.Trim();
            //新增答案
            if (this.Answewr.Text == "")
            {
                this.ltl1.Text += "請輸入答案! ";
                inputError = true;
            }
            modelTest.TestAnswer = this.Answewr.Text;
            //新增檔案狀態
            modelTest.IsEnable = Convert.ToInt32(this.intEnable.SelectedValue);
            if (inputError == false)
            { //存入資料庫
                _mgr_Test.CreateTest(modelTest);
                Response.Write("<script>alert('新增成功!!')</script>");
            }
            else {
                return;
            }

          
        }
    }
}