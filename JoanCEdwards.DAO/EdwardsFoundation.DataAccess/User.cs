using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JoanCEdwards.DAO;

namespace EdwardsFoundation.DataAccess
{
    public class User : IUser
    {
        ExamSystemDataContext db;

        public User()
        {
            db = new ExamSystemDataContext();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public char UserType { get; set; }

        public string GradeLevel { get; set; }

        public int Save()
        {
            UserProfile user = new UserProfile() { FirstName = this.FirstName, LastName = this.LastName, EmailAddress = this.EmailAddress, UserType = this.UserType, GradeLevel = this.GradeLevel };
            db.UserProfiles.InsertOnSubmit(user);
            db.SubmitChanges();
            return user.UserId;
        }
    }
}
