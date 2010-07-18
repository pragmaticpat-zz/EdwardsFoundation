using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace JoanCEdwards.ExamLibrary
{
    /// <summary>
    /// NOTE: THIS CLASS IS NOT TESTED OR VALIDATED
    /// </summary>
    class SendMailer
    {
        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="toAddress">To address.</param>
        /// <param name="messageBody">The message body.</param>
        /// <param name="replacements">The replacements.</param>
        public static void SendMail(string toAddress, string messageBody, Dictionary<string, string> replacements, string subject)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(Configuration.EmailFromAddress);
            message.To.Add(toAddress);
            message.Body = GetBody(messageBody, replacements);
            message.IsBodyHtml = false;
            message.Subject = subject;

            SmtpClient client = new SmtpClient(Configuration.SmtpHost, Configuration.SmtpPort);
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <param name="messageBody">The message body.</param>
        /// <param name="replacements">The replacements.</param>
        /// <returns></returns>
        private static string GetBody(string messageBody, Dictionary<string, string> replacements)
        {
            string newBody = messageBody;
            foreach (var keyValuePair in replacements)
            {
                newBody = newBody.Replace("$" + keyValuePair.Key + "$", keyValuePair.Value);
            }
            return newBody;
        }

    }
}
