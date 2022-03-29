using Sakei.Manager.ExamSystemManagers;
using Sakei.Models.ExamSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei.ShareControls
{
    public partial class ucExamReviewExtraWindow : System.Web.UI.UserControl
    {
        private MessageBoardManager _msgBoardManager = new MessageBoardManager();
        private UserAnswerManager _noteManager = new UserAnswerManager();
        public List<UserAnswerModel> userAnswer { get; set; }
        public string NoteContent { get; set; }
        public Guid UserID { get; set; }
        public Guid TestID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void Change()
        {
            for (var i = 0; i < userAnswer.Count; i++)
            {
                if (userAnswer[i].TestID == TestID)
                {
                    this.txtNote.Text = userAnswer[i].UserNote;
                    return;
                }
            }
        }

    }
}