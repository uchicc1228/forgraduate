using Sakei.Manager.ExamSystemManagers;
using SaKei.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei.ExamSystem
{
    public partial class ExamReview : System.Web.UI.Page
    {
        private ExamDataManager _mgr = new ExamDataManager();
        private const int _pageSize = 10;
        private int _testLevel;
        protected void Page_Load(object sender, EventArgs e)
        {
            //存入頁面要顯示的考題等級
            string testReviewLevelText = this.Request.QueryString["Level"];
            try
            {
                if (string.IsNullOrWhiteSpace(testReviewLevelText) || !int.TryParse(testReviewLevelText, out _testLevel))
                    //_testLevel = (int)LoginHelper.GetUserLevel();
                    _testLevel = 1;
                else
                    _testLevel = Convert.ToInt32(testReviewLevelText);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("存取不到使用者等級", ex);
                throw;
            }
            int pageIndex;
            //判斷當前頁數
            string pageIndexText = this.Request.QueryString["Index"];
            if (string.IsNullOrWhiteSpace(pageIndexText) || !int.TryParse(pageIndexText, out pageIndex))
                pageIndex = 1;
            else
                pageIndex = Convert.ToInt32(pageIndexText);

            int totalRows;

            var list = this._mgr.GetTestDataList(_testLevel, _pageSize, pageIndex, out totalRows);

            if (list.Count == 0)
            {
                this.rptTestList.Visible = false;
                this.plcEmpty.Visible = true;
            }
            else
            {
                this.rptTestList.Visible = true;
                this.plcEmpty.Visible = false;

                this.rptTestList.DataSource = list;
                this.rptTestList.DataBind();
            }


        }
    }
}