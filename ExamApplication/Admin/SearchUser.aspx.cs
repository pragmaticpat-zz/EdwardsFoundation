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
using System.Data.SqlClient;

namespace ExamApplication.Admin
{
    public partial class SearchUser : System.Web.UI.Page
    {
        private void SetPageLabels()
        {
            this.labelSearchUser.Text = ExamAppResources.labelSearchUsersTextBox;
            this.buttonSearchUsers.Text = ExamAppResources.lableSearchUsersSearchButton;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SetPageLabels();
                this.SearchUsers("");
            }
            
        }

        protected void buttonSearchUsers_Click(object sender, EventArgs e)
        {

        }

        protected void gridViewUsers_OnEdit(object sender, EventArgs e)
        {
            DataGridCommandEventArgs eventArgs = (DataGridCommandEventArgs)e;
            //this.gridViewUsers.SelectedIndex = e.Item.ItemIndex;
            //this.gridViewUser
        }

        protected void gridViewUsers_SelectedIndexChange(object sender, EventArgs e)
        {
            object s = sender;
        }        

        private void SearchUsers(string searchString)
        {
            this.gridViewUsers.DataSource = JoanCEdwards.ExamLibrary.User.GetUsers(searchString);
            this.gridViewUsers.DataBind(); 
            
        }


    }
}
