using JuniorMath.ApplicationCore.Entities.CommonAggregate;
using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JuniorMath.ApplicationCore.Entities.UserAggregate
{
    public partial class SiteUser : BaseEntity
    {
        public SiteUser()
        {
            AddressCreatedByNavigation = new HashSet<Address>();
            AddressUpdatedByNavigation = new HashSet<Address>();
            QuestionCreatedByNavigation = new HashSet<Question>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        public int SiteUserLevelId { get; set; }
        public bool Active { get; set; }
        public string Note { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual SiteUserLevel SiteUserLevel { get; set; }
        public virtual ICollection<Address> AddressCreatedByNavigation { get; set; }
        public virtual ICollection<Address> AddressUpdatedByNavigation { get; set; }
        public virtual ICollection<Question> QuestionCreatedByNavigation { get; set; }
    }
}
