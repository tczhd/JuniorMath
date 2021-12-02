using JuniorMath.ApplicationCore.Entities.CommonAggregate;
using JuniorMath.ApplicationCore.Entities.ExaminationPaperAggregate;
using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Entities.StudentAggregate;
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
            ExaminationPaperCreatedByNavigation = new HashSet<ExaminationPaper>();
            StudentExaminationPaperCreatedByNavigation = new HashSet<StudentExaminationPaper>();
            StudentExaminationPaperSiteUserIdNavigation = new HashSet<StudentExaminationPaper>();
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
        public virtual ICollection<StudentExaminationPaperQuestionAnswer> StudentSiteUserIdNavigation { get; set; }
        public virtual ICollection<ExaminationPaper> ExaminationPaperCreatedByNavigation { get; set; }
        public virtual ICollection<StudentExaminationPaper> StudentExaminationPaperSiteUserIdNavigation { get; set; }
        public virtual ICollection<StudentExaminationPaper> StudentExaminationPaperCreatedByNavigation { get; set; }
    }
}
