using Sakei.Helper;
using Sakei.Manager.ExamSystemManagers;
using Sakei.Models.ExamSystemModels;
using SaKei.Helpers;
using SaKei.Manager;
using SaKei.Models;
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
        private ExamDataManager _mgrExamData = new ExamDataManager();
        private UserAnswerManager _mgrUserAnswer = new UserAnswerManager();
        private AccountManager _mgrAccount = new AccountManager();
        private const int _pageSize = 10;
        private int _testLevel;
        private Guid _userID;
        private List<Guid> _testIDList = new List<Guid>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //存入頁面要顯示的考題等級
            string testReviewLevelText = this.Request.QueryString["Level"];
            try
            {
                _userID = (Guid)LoginHelper.GetUserID();
                //取得等級
                if (string.IsNullOrWhiteSpace(testReviewLevelText) || !int.TryParse(testReviewLevelText, out _testLevel))
                    _testLevel = _mgrAccount.GetUserPointsAndMoney(_userID).UserLevel;
                else
                    _testLevel = Convert.ToInt32(testReviewLevelText);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("存取不到使用者資料", ex);
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
            //取得考題資料清單
            var examList = this._mgrExamData.GetTestDataList(_testLevel, _pageSize, pageIndex, out totalRows);
            for (var i = 0; i < examList.Count; i++)
            {

            }
            var userAnswerList = _mgrUserAnswer.GetUserAnswerList(_userID, examList);
            if (examList.Count == 0)
            {
                this.rptTestList.Visible = false;
                this.plcEmpty.Visible = true;
            }
            else
            {
                this.rptTestList.Visible = true;
                this.plcEmpty.Visible = false;

                this.rptTestList.DataSource = examList;
                this.rptTestList.DataBind();

                this.ucExamReviewExtraWindow.UserID = _userID;
            }


        }
    }
}