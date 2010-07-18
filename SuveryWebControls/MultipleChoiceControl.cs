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
    [ToolboxData("<{0}:WebCustomControl1 runat=server></{0}:WebCustomControl1>")]
    public class MultipleChoiceControl : BaseQuestionControl
    {
        private RadioButtonList _optionsRadioButtons = null;
        private RequiredFieldValidator _validator = null;
        private const string RADIO_LIST_ID = "optionsRadioList";

        //[DefaultValue((string)null), MergableProperty(false), PersistenceMode
        //  (PersistenceMode.InnerDefaultProperty), 
        //  Editor("System.Web.UI.Design.WebControls.ListItemsCollectionEditor,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))] 
        public ListItemCollection Items
        {
            get 
            {
                if (ViewState["Items"] == null)
                {
                    ViewState["Items"] = new ListItemCollection();
                }
                return (ListItemCollection)ViewState["Items"]; 
            }
        }

        /// <summary>
        /// Gets the answer value.
        /// </summary>
        /// <value>The answer value.</value>
        public int AnswerValue
        {
            get
            {
                this.EnsureChildControls();
                return (this._optionsRadioButtons.SelectedIndex > -1) ? int.Parse(this._optionsRadioButtons.SelectedValue) : 0;
            }
        }

        public ListItem SelectedAnswer
        {
            get
            {
                this.EnsureChildControls();
                return this._optionsRadioButtons.SelectedItem;
            }
            set
            {
                this.EnsureChildControls();
                this._optionsRadioButtons.SelectedIndex = this._optionsRadioButtons.Items.IndexOf(this._optionsRadioButtons.Items.FindByText(value.Text));
            }
        }

        public bool IsValid
        {

            get
            {
                this.EnsureChildControls();
                return this._optionsRadioButtons.SelectedIndex > -1;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            this.EnsureChildControls();
            output.Write(Text);
            this._optionsRadioButtons.RenderControl(output);            
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            this._optionsRadioButtons = new RadioButtonList();
            this._optionsRadioButtons.ID = RADIO_LIST_ID;
            this._optionsRadioButtons.Items.Clear();

            System.Diagnostics.Debug.Assert(this.Items.Count > 0, "Count is not greater Than 0");
            if (this.Items.Count > 0)
            {
                foreach (ListItem li in this.Items)
                {
                    this._optionsRadioButtons.Items.Add(li);
                }
                
                this._validator = new RequiredFieldValidator();
                this._validator.ControlToValidate = RADIO_LIST_ID;
                this._validator.ErrorMessage = this.RequiredErrorMessage;
                this._optionsRadioButtons.CausesValidation = true;
            }

            this.Controls.Add(this._optionsRadioButtons);
            if (this._validator != null)
            {
                this.Controls.Add(this._validator);
            }
        }
    }
}
