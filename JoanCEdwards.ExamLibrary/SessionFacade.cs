using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using JoanCEdwards.DAO;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;

namespace JoanCEdwards.ExamLibrary
{
    /// <summary>
    /// Class is a Facade to expose all session variables being used in the application.
    /// </summary>
    public class SessionFacade
    {
        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <value>The user profile.</value>
        public static UserProfile UserProfile
        {
            get
            {
                return System.Web.HttpContext.Current.Session["UserProfile"] as UserProfile;
            }
            set
            {
                System.Web.HttpContext.Current.Session["UserProfile"] = value;
            }
        }
    }
}
