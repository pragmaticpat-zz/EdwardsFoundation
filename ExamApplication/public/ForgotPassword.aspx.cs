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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Title = ExamAppResources.pageTitlesForgotPassword;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SetLabels();
            }
        }
        private void SetLabels()
        {
            labelUserName.Text = ExamAppResources.loginControlUserNameLabel;
            labelForgotPasswordInstructions.Text = ExamAppResources.labelControlPasswordRecoveryInstruction;
        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text;
            if (userName != "" && JoanCEdwards.ExamLibrary.User.Exists(userName))
            {
                string newPassword = JoanCEdwards.ExamLibrary.User.ResetPassword(userName);
                //Send Password
            }
            else
            {
                labelError.Text = "The Email Address you have entered does not exist.";
            }
        }
    }
}
