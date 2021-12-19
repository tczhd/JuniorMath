using JuniorMath.ApplicationCore.Entities.ExamAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.StudentAggregate
{
    public partial class StudentExam : BaseEntity
    {
        public StudentExam()
        {
            StudentExamQuestionAnswerCollection = new HashSet<StudentExamQuestionAnswer>();
        }
        public int EaxmId { get; set; }
        public string Notes { get; set; }
        public int? TotalMarks { get; set; }
        public bool Submitted { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int SubmittedBy { get; set; }
        public virtual SiteUser SubmittedByNavigation { get; set; }
        public virtual Exam ExamIdNavigation { get; set; }
        public virtual ICollection<StudentExamQuestionAnswer> StudentExamQuestionAnswerCollection { get; set; }
    }
}
