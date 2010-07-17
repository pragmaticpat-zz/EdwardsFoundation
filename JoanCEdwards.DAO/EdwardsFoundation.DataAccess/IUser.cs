﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdwardsFoundation.DataAccess
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        char UserType { get; set; }
        string GradeLevel { get; set; }
        int Save();
    }
}
