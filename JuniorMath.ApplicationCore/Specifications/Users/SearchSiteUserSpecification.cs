using JuniorMath.ApplicationCore.Entities.UserAggregate;
using JuniorMath.ApplicationCore.Enums;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JuniorMath.ApplicationCore.Specifications.Users
{
    public class SearchSiteUserSpecification : BaseSpecification<SiteUser>
    {
        public SearchSiteUserSpecification() : base()
        {
            AddInclude(b => b.SiteUserLevel);
        }

        public void AddSiteUserLevels(List<SiteUserLevelType> SiteUserTypes)
        {
            var userTypes = SiteUserTypes.Select(p => (int)p).ToList();
            AddCriteria(q => userTypes.Contains(q.SiteUserLevelId));
        }
    }
}
