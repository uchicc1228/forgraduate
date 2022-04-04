using Sakei.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei.ShareControls
{
    public partial class ucNoteAndMsgBoard : System.Web.UI.UserControl
    {
        public Guid UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = (Guid)LoginHelper.GetUserID();
        }
    }
}