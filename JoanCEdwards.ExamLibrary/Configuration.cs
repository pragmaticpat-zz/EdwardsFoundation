using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace JoanCEdwards.ExamLibrary
{
    class Configuration
    {
        public static string EmailFromAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["EmailFromAddress"] ?? "";
            }
        }
        public static string SmtpHost 
        {
            get
            {
                return ConfigurationManager.AppSettings["SmtpHost"] ?? "localhost";
            }
        }
        public static int SmtpPort
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["SmtpHost"] ?? "25");
            }
        }
        public static string HashKey
        {
            get
            {
                return ConfigurationManager.AppSettings["PasswordHashKey"] ?? "625222633e7c4c223e364429405632573f6438354c3577497d4f496d55";
            }
        }
    }
}
