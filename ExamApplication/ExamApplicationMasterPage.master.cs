using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ExamApplication
{
    public partial class ExamApplicationMasterPage : System.Web.UI.MasterPage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //this.linkButtonLogOut.Visible = false;
                panelMenu.Visible = false;
            }
            else
            {
                panelMenu.Visible = true;
            }
        }

        protected void menuLinkButton_Click(object sender, EventArgs e)
        {
            string redirectUrl = "";
            switch (((Control)sender).ID)
            {
                case "Home":
                    redirectUrl = "~/";
                    break;
                case "Exams":
                    redirectUrl = "~/Exam.aspx";
                    break;
                case "ManageUsers":
                    redirectUrl = "~/Admin/SearchUser.aspx";
                    break;
                case "ManageExams":
                    redirectUrl = "";
                    break;
                default:
                    break;
            }
            Response.Redirect(redirectUrl);
        }

        protected void linkButtonLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.LoginUrl);
        }
    }
}
