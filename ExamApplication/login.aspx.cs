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
using JoanCEdwards.DAO;

namespace ExamApplication
{
    public partial class login : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.loginControl.PasswordLabelText = ExamAppResources.loginControlPasswordLabel;
            this.loginControl.UserNameLabelText = ExamAppResources.loginControlUserNameLabel;
            this.loginControl.PasswordRecoveryText = ExamAppResources.loginControlPasswordRecoverLabel;
            this.loginControl.FailureText = ExamAppResources.loginControlAuthenticationFailed;
            this.Title = ExamAppResources.pageTitlesLoginPage;
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginControl_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (this.IsUserValid(this.loginControl.UserName, this.loginControl.Password))
            {
                UserProfile profile = JoanCEdwards.ExamLibrary.User.GetUser(this.loginControl.UserName);
                JoanCEdwards.ExamLibrary.SessionFacade.UserProfile = profile;
                FormsAuthentication.RedirectFromLoginPage(this.loginControl.UserName, this.loginControl.RememberMeSet);
            }
        }
        private bool IsUserValid(string userName, string password)
        {
            return JoanCEdwards.ExamLibrary.User.IsValid(userName, password);
        }
    }
}
