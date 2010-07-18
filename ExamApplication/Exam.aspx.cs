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
using JoanCEdwards.ExamLibrary;
using System.Collections.Generic;
using SuveryWebControls;
using System.Text;

namespace ExamApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.BuildExamControls();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void BuildExamControls()
        {
            Exam exam = ExamFactory.GetExam("TestExam");
            this.literalHeader.Text = exam.Title ?? "";
            this.literalInstructions.Text = exam.Instructions ?? "";

            if (exam.Sections == null || exam.Sections.Length == 0)
            {
                labelError.Text = "Exam has no sections";
                return;
            }
            foreach (Section section in exam.Sections)
            {
                this.BuildSections(section);
            }

            this.BuildExamButtons();

        }
        private void BuildSections(Section section)
        {
            if (section.Questions == null || section.Questions.Length == 0)
            {
                labelError.Text = string.Format("Section {0} has no questions.");
                return;
            }
            foreach (Question question in section.Questions)
            {
                this.BuildQuestionControls(question);
            }
        }
        private void BuildQuestionControls(Question question)
        {
            WebControl control = null;
            switch (question.Type)
            {
                case "MultipleChoice":
                    MultipleChoiceControl mc = new SuveryWebControls.MultipleChoiceControl();
                    mc.Text = question.QuestionText;
                    this.LoadOptions(mc, question.Options);
                    control = mc;
                    break;
                case "ShortAnswer":
                    ShortAnswerControl sc = new ShortAnswerControl();
                    sc.Text = question.QuestionText;
                    control = sc;
                    break;
                default:
                    throw new ArgumentException(string.Format("Question Type of {0} is not supported", question.Type));
                    break;
            }
            control.ID = question.Id;
            panelQuestions.Controls.Add(control);
        }

        private void LoadOptions(MultipleChoiceControl multipleChoiceControl, Option[] options)
        {
            if(options != null && options.Length > 0)
            {
                foreach(Option option in options)
                {
                    multipleChoiceControl.Items.Add(new ListItem(option.OptionText, option.PointValue));
                }
            }
        }
        private void BuildExamButtons()
        {
            Button submitButton = new Button();
            submitButton.ID = "submitButton";
            submitButton.Text = ExamAppResources.submitButtonText;
            submitButton.Click += new EventHandler(submit_Click);
            submitButton.CausesValidation = true;
            this.panelButtons.Controls.Add(submitButton);

            //TODO: Enable and Create
            //Button clearButton = new Button();
            //clearButton.ID = "clearButton";
            //clearButton.Text = Resources.clearButtonText;
            
        }

        void submit_Click(object sender, EventArgs e)
        {
            if (this.IsQuestionCompletionValid())
            {

            }
            
            ControlCollection cc = this.panelQuestions.Controls;
        }

        /// <summary>
        /// Determines whether [is question completion valid].
        /// NOTE: This is a poor man's validator because I couldn't get validation up.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is question completion valid]; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsQuestionCompletionValid()
        {
            StringBuilder errorMessageList = new StringBuilder();
            bool isValid = true;
            foreach (Control question in this.panelQuestions.Controls)
            {
                if (question is MultipleChoiceControl)
                {
                    MultipleChoiceControl mcControl = (MultipleChoiceControl)question;
                    if (!mcControl.IsValid)
                    {
                        isValid = false;
                        errorMessageList.Append("<br />").Append(mcControl.RequiredErrorMessage);
                    }
                }
                else if (question is ShortAnswerControl)
                {
                    ShortAnswerControl mcControl = (ShortAnswerControl)question;
                }
            }
            return true;
        }


    }
}
