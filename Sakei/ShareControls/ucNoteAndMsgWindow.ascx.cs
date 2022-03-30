using Sakei.Models.ExamSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei.ShareControls
{
    public partial class ucNoteAndMsgWindow : System.Web.UI.UserControl
    {
        public Guid testID { get; set; }
        public Guid userID { get; set; }
        public List<UserAnswerModel> userAnswerList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void NoteChange()
        {
            string noteContent;
            for (var i = 0; i < userAnswerList.Count; i++)
            {
                if (userAnswerList[i].TestID == testID)
                {
                    noteContent = userAnswerList[i].UserNote;
                    this.txtNote.Text = noteContent;
                    return;
                }
            }
        }
        public void MsgBoardChange()
        {
            
        }

    }
}