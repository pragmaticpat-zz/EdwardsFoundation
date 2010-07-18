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

namespace ExamWeb
{
    /// <summary>
    /// Template to be used in databinding to add an edit button functionality to the datagrid.
    /// </summary>
    public class editButtonTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            container.Controls.Add(new Button());
            container.DataBinding += new EventHandler(container_DataBinding);
        }

        void container_DataBinding(object sender, EventArgs e)
        {
            DataControlFieldCell container = (DataControlFieldCell)sender;
            Button button = (Button)container.Controls[0];
            button.Text = "Edit";
            button.ID = "EditButton";
            if (EditClickEvent != null)
            {
                button.Click += this.EditClickEvent;

            }
            button.CommandArgument = ((System.Web.Security.MembershipUser)((GridViewRow)container.NamingContainer).DataItem).UserName;
        }

        private EventHandler _clickEvent = null;
        public EventHandler EditClickEvent 
        {
            get
            {
                return this._clickEvent;
            }
            set
            {
                this._clickEvent = value;
            }
        }
    }

    /// <summary>
    /// TODO: Implement an edit page so that the edit functionality Works.
    /// </summary>
    public partial class SearchUser : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            TemplateField tf = new TemplateField();
            tf.HeaderText = "";
            editButtonTemplate template = new editButtonTemplate();
            template.EditClickEvent = new EventHandler(editUser_Click);
            tf.ItemTemplate = template;
            
            GridView1.Columns.Add(tf);
        }

        protected void editUser_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Need to implement a edit page.");
            //Response.Redirect("EditUser.aspx?User=" + ((Button)sender).CommandArgument);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var collection = Membership.GetAllUsers();
            GridView1.DataSource = collection;
            GridView1.DataBind();

            if (IsPostBack)
            {
                string test = Request["EditButton"];
            }
        }
    }
}
