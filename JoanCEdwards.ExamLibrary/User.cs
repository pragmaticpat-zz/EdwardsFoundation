using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using JoanCEdwards.DAO;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;

namespace JoanCEdwards.ExamLibrary
{
    /// <summary>
    /// User Business Class
    /// </summary>
    public class User
    {
        public enum Type
        {
            Student = 1,
            Mentor = 2,
            Directory = 3
        }

        /// <summary>
        /// Determines whether the specified user and password is valid.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// 	<c>true</c> if the specified user name is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValid(string userName, string password)
        {
            bool isValid = false;
            UserProfile profile = GetUser(userName);
            if (profile != null && profile.Password.Equals(HashPassword(password)))
            {
                isValid = true;
            }
            return isValid;
        }

        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="valueToHash">The value to hash.</param>
        /// <returns></returns>
        public static string HashPassword(string valueToHash)
        {
            return CreateHash(valueToHash, Configuration.HashKey);
        }

        /// <summary>
        /// Creates the hash.
        /// </summary>
        /// <param name="valueToHash">The value to hash.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private static string CreateHash(string valueToHash, string key)
        {
            string valueToReturn = "";
            string hashKey = valueToHash + key;

            using (SHA1 sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(hashKey));
                valueToReturn = Convert.ToBase64String(hash);
            }
            return valueToReturn;
        }

        /// <summary>
        /// Existses the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public static bool Exists(string userName)
        {
            return false;
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public static string ResetPassword(string userName)
        {
            throw new Exception("Not Implemented");
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static UserProfile GetUser(string email)
        {
            UserProfile profile = null;
            using (ExamSystemDataContext db = new ExamSystemDataContext())
            {
                profile = (from p in db.UserProfiles
                           where p.EmailAddress == email
                            select p).FirstOrDefault();
            }
            return profile;
        }
        public static UserProfile Save(UserProfile profile)
        {
            if (profile.UserId == 0)
            {
                //save the user.
                using (ExamSystemDataContext db = new ExamSystemDataContext())
                {
                    db.UserProfiles.InsertOnSubmit(profile);
                    db.SubmitChanges();
                }
                
            }
            else
            {
                //update user
            }
            return null;
        }

        public static List<UserProfile> GetUsers(string searchString)
        {
            List<UserProfile> profiles = null;
            using (ExamSystemDataContext db = new ExamSystemDataContext())
            {
                if (string.IsNullOrEmpty(searchString))
                {
                    profiles = (from p in db.UserProfiles 
                                select p).ToList();
                }
                else
                {
                    profiles = (from p in db.UserProfiles 
                                where SqlMethods.Like(p.EmailAddress, searchString)  
                                select p).ToList();
                }
            }
            return profiles;
        }

    }
}
