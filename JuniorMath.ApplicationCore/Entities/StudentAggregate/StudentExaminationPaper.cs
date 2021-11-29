using JuniorMath.ApplicationCore.Entities.ExaminationPaperAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.StudentAggregate
{
    public partial class StudentExaminationPaper : BaseEntity
    {
        public StudentExaminationPaper()
        {
        }
        public int StudentSiteUserId { get; set; }
        public int ExaminationPaperId { get; set; }
        public string Description { get; set; }
        public int? TotalMarks { get; set; }
        public bool Submitted { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public virtual SiteUser StudentSiteUserIdNavigation { get; set; }
        public virtual SiteUser CreatedByNavigation { get; set; }
        public virtual ExaminationPaper ExaminationPaperIdNavigation { get; set; }
    }
}
