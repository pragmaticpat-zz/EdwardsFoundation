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
using JoanCEdwards.DAO;

namespace ExamApplication.Admin
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ValidatorEmailAddress.ErrorMessage = ExamAppResources.labelEmailAddressRequired;
                this.ValidatorFirstName.ErrorMessage = ExamAppResources.labelFirstNameRequired;
                this.ValidatorLastName.ErrorMessage = ExamAppResources.labelLastNameRequired;
                this.ValidatorGradeLevel.ErrorMessage = ExamAppResources.lableGradeLevelRequired;
                this.ValidatorConfirmPassword.ErrorMessage = "Confirm Pass Does not match";
                this.ValidatorPassword.ErrorMessage = "Password is a required field.";
                this.CompareValidatorPassword.ErrorMessage = "Your Password and Confirm Password does not match.";

                foreach(JoanCEdwards.ExamLibrary.User.Type enumValue in Enum.GetValues(typeof(JoanCEdwards.ExamLibrary.User.Type)))
                {
                    string value = Convert.ToInt32(enumValue).ToString();
                    this.DropDownListUserType.Items.Add(new ListItem(enumValue.ToString(), value));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile();
            profile.EmailAddress = TextBoxEmail.Text;
            profile.FirstName = TextBoxFirstName.Text;
            profile.LastName = TextBoxLastName.Text;
            profile.GradeLevel = TextBoxGradeLevel.Text;
            profile.UserType = DropDownListUserType.SelectedValue[0];
            profile.Password = JoanCEdwards.ExamLibrary.User.HashPassword(TextBoxPassword.Value);

            UserProfile newProfile = JoanCEdwards.ExamLibrary.User.Save(profile);
            Response.Redirect("SearchUser.aspx");
        }


    }
}
