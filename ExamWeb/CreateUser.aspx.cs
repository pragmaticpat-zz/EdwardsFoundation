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
using JoanCEdwards.ExamLibrary;
using System.Web.Profile;
using System.Web.Security;

namespace ExamWeb
{
    public partial class CreateUser : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }

        // CreatedUser event is called when a new user is successfully created
        public void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {

            // Create an empty Profile for the newly created user
            //ProfileCommon profile = (ProfileCommon)ProfileCommon.Create(CreateUserWizard1.UserName, true);
            CommonUserProfile profile = (CommonUserProfile)CommonUserProfile.Create(CreateUserWizard1.UserName, true);
            // Populate some Profile properties off of the create user wizard
            profile.FirstName = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Age")).Text;
            profile.LastName = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Age")).Text;
            profile.GraduatingClassYear = Int32.Parse(((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("GraduatingClass")).Text);
            profile.StreetAddress1 = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("StreetAddress1")).Text;
            profile.StreetAddress2 = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("StreetAddress2")).Text;
            profile.City = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("City")).Text;
            profile.State = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("State")).Text;
            profile.ZipCode = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Zip")).Text;

            // Save the profile - must be done since we explicitly created this profile instance
            profile.Save();
        }

        // Activate event fires when the user hits "next" in the CreateUserWizard
        public void AssignUserToRoles_Activate(object sender, EventArgs e)
        {

            // Databind list of roles in the role manager system to a listbox in the wizard
            AvailableRoles.DataSource = Roles.GetAllRoles(); ;
            AvailableRoles.DataBind();
        }

        // Deactivate event fires when user hits "next" in the CreateUserWizard 
        public void AssignUserToRoles_Deactivate(object sender, EventArgs e)
        {

            // Add user to all selected roles from the roles listbox
            for (int i = 0; i < AvailableRoles.Items.Count; i++)
            {
                if (AvailableRoles.Items[i].Selected == true)
                    Roles.AddUserToRole(CreateUserWizard1.UserName, AvailableRoles.Items[i].Value);
            }
        }
    }
}
