using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuveryWebControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:BaseQuestionControl runat=server></{0}:BaseQuestionControl>")]
    public class BaseQuestionControl : CompositeControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                return (string)ViewState["Text"] ?? "";
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        public string RequiredErrorMessage
        {
            get
            {
                return string.Format((string)ViewState["RequiredErrorMessage"] ?? ((QuestionNumber == 0) ? "This Question is Required" : "Question {0} is Required."), this.QuestionNumber);
            }
            set
            {
                ViewState["RequiredErrorMessage"] = value;
            }
        }

        public int QuestionNumber
        {
            get
            {
                return ViewState["QuestionNumber"] == null ? 0 : (int)ViewState["QuestionNumber"];
            }
            set
            {
                ViewState["QuestionNumber"] = value;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ViewState["IsReadOnly"] == null ? false : (bool)ViewState["IsReadOnly"];
            }
            set
            {
                ViewState["IsReadOnly"] = value;
            }
        }
    }
}
