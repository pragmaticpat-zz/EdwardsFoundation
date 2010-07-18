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
    [ToolboxData("<{0}:ShortAnswerControl runat=server></{0}:ShortAnswerControl>")]
    public class ShortAnswerControl : BaseQuestionControl
    {
        private TextBox _answerTextBox = null;
        
        public string Answer
        {
            get 
            {
                this.EnsureChildControls();
                return this._answerTextBox.Text;
            }
            set 
            {
                this.EnsureChildControls();
                this._answerTextBox.Text = value;
            }
        }
	

        protected override void RenderContents(HtmlTextWriter output)
        {
            EnsureChildControls();
            output.Write(Text);
            _answerTextBox.RenderControl(output);
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();

            this._answerTextBox = new TextBox();
            this._answerTextBox.TextMode = TextBoxMode.MultiLine;
            this._answerTextBox.ID = "TextBoxAnswer";
            this.Controls.Add(this._answerTextBox);
        }
    }
}
