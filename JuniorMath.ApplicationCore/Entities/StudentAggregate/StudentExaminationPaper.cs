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
            StudentExaminationPaperQuestionAnswerNavigation = new HashSet<StudentExaminationPaperQuestionAnswer>();
        }
        public int SiteUserId { get; set; }
        public int PaperId { get; set; }
        public string Notes { get; set; }
        public int? TotalMarks { get; set; }
        public bool Submitted { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public virtual SiteUser SiteUserIdNavigation { get; set; }
        public virtual SiteUser CreatedByNavigation { get; set; }
        public virtual ExaminationPaper PaperIdNavigation { get; set; }
        public virtual ICollection<StudentExaminationPaperQuestionAnswer> StudentExaminationPaperQuestionAnswerNavigation { get; set; }
    }
}
