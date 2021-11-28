using JuniorMath.ApplicationCore.Entities;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Specifications.Users
{
    public class UserContextSpefification : BaseSpecification<SiteUser>
    {
        public UserContextSpefification() : base()
        {
            AddInclude(b => b.SiteUserLevel);
            AddInclude(b => b.Clinic);
            AddInclude(b => b.Clinic.Address);
            AddInclude(b => b.Doctor);
        }

        public void AddUserId(string userId)
        {
            AddCriteria(q => q.UserId == userId);
        }
    }
}
