using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace JuniorMath.ApplicationCore.Entities.UserAggregate
{
    public class AspNetUser : IdentityUser
    {
        public virtual ICollection<SiteUser> SiteUsers { get; set; }
    }
}
