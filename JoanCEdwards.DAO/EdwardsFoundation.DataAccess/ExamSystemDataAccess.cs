using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JoanCEdwards.DAO;

namespace EdwardsFoundation.DataAccess
{
    public class ExamSystemDataAccess
    {
        public IUser CreateUser(string emailAddress, string firstName, string lastName, char userType, string gradeLevel, string password )
        {
            var db = new ExamSystemDataContext();
            var userProfile = new UserProfile() { EmailAddress = emailAddress, FirstName = firstName, LastName = lastName, UserType = userType, GradeLevel = gradeLevel, Password = password };
            db.UserProfiles.InsertOnSubmit(userProfile);
            db.SubmitChanges();
            return userProfile;
        }

        public IUser GetUserByEmailAddress(string p)
        {
            var db = new ExamSystemDataContext();
            var user = (from u in db.UserProfiles
                       where u.EmailAddress == p
                       select u).FirstOrDefault();
            return user;
        }
    }
}
