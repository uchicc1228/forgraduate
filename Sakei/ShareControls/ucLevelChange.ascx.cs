using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakei.ShareControls
{
    public partial class ucLevelChange : System.Web.UI.UserControl
    {
        private string _url = null;
        private string Url
        {
            get
            {
                if (this._url == null)
                    return Request.Url.LocalPath;
                else
                    return this._url;
            }
            set
            {
                this._url = value;
            }
        }


        protected void btnLV_Click(object sender, EventArgs e)
        {
            string url = this.Url;
            int key = 0;

            if (sender == this.btnLV1)
            {
                key = 1;
            }
            else if (sender == this.btnLV2)
            {
                key = 2;
            }
            else if (sender == this.btnLV3)
            {
                key = 3;
            }
            else if (sender == this.btnLV4)
            {
                key = 4;
            }
            else if (sender == this.btnLV5)
            {
                key = 5;
            }
            else if (sender == this.btnLV)
            {
                key = 0;
            }
            url = url + "?key=" + key;
            Response.Redirect(url);
        }



    }
}