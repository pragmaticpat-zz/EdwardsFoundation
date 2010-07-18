using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;
using System.Web.Security;

namespace JoanCEdwards.ExamLibrary
{
    public class CommonUserProfile : ProfileBase

    {
        public static CommonUserProfile CurrentUser
        {
            get
            {
                return (CommonUserProfile)
                       (ProfileBase.Create(Membership.GetUser().UserName));
            }
        }

        public static CommonUserProfile GetUserProfile(string username, bool isAuthenticated)
        {
            return Create(username, isAuthenticated) as CommonUserProfile;
        }

        public static CommonUserProfile GetUserProfile()
        {
            return Create(Membership.GetUser().UserName) as CommonUserProfile;
        }

        [SettingsAllowAnonymous(false)]
        public string FirstName
        {
            get { return ((string)(base["FirstName"])); }
            set { base["FirstName"] = value; Save(); }
        }

        [SettingsAllowAnonymous(false)]
        public string LastName
        {
            get { return ((string)(base["LastName"])); }
            set { base["LastName"] = value; Save(); }
        }
        [SettingsAllowAnonymous(false)]
        public Int32 GraduatingClassYear
        {
            get { return ((Int32)(base["GraduatingClassYear"])); }
            set { base["GraduatingClassYear"] = value; Save(); }
        }
        [SettingsAllowAnonymous(false)]
        public string StreetAddress1
        {
            get { return ((string)(base["StreetAddress1"])); }
            set { base["StreetAddress1"] = value; Save(); }
        }
        [SettingsAllowAnonymous(false)]
        public string StreetAddress2
        {
            get { return ((string)(base["StreetAddress2"])); }
            set { base["StreetAddress2"] = value; Save(); }
        }
        [SettingsAllowAnonymous(false)]
        public string City
        {
            get { return ((string)(base["City"])); }
            set { base["City"] = value; Save(); }
        }
        [SettingsAllowAnonymous(false)]
        public string State
        {
            get { return ((string)(base["State"])); }
            set { base["State"] = value; Save(); }
        }
        [SettingsAllowAnonymous(false)]
        public string ZipCode
        {
            get { return ((string)(base["ZipCode"])); }
            set { base["ZipCode"] = value; Save(); }
        }
    }
}
