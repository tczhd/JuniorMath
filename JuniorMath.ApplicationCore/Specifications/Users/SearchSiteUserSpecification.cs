using JuniorMath.ApplicationCore.Entities.UserAggregate;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Specifications.Users
{
    public class SearchSiteUserSpecification : BaseSpecification<SiteUser>
    {
        public SearchSiteUserSpecification() : base()
        {
            AddInclude(b => b.SiteUserLevel);
        }
    }
}
