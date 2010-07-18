using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ExamApplication.Admin
{
    public partial class ManageUsersSearch : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.BuildMenuPanel();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        private void BuildMenuPanel()
        {
            foreach (var value in Enum.GetValues(typeof(UserManagerTasks)))
            {
                LinkButton menuLinkButton = new LinkButton();
                menuLinkButton.ID = value.ToString();
                menuLinkButton.Text = menuLinkButton.ID;
                menuLinkButton.Click += new EventHandler(menuLinkButton_Click);

            }
        }

        void menuLinkButton_Click(object sender, EventArgs e)
        {
            this.ProcessMenuLinkButtonClick(((LinkButton)sender).ID));
        }

        enum UserManagerTasks
        {
            SearchUsers,
            CreateUser
        }
        private void ProcessMenuLinkButtonClick(string id)
        {
            UserManagerTasks task = (UserManagerTasks)Enum.Parse(typeof(UserManagerTasks), id);
            switch (task)
            {
                case UserManagerTasks.SearchUsers:
                    this.DisplaySearchUsers();
                    break;
                case UserManagerTasks.CreateUser:
                    break;
                default:
                    break;
            }
        }

        private void DisplaySearchUsers()
        {
            panelUserManagement.
        }
    }
}
