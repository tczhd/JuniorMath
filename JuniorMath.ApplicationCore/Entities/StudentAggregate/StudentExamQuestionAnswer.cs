using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.StudentAggregate
{
    public partial class StudentExamQuestionAnswer : BaseEntity
    {
        public StudentExamQuestionAnswer()
        {
            StudentExamQuestionAnswerDetailCollection = new HashSet<StudentExamQuestionAnswerDetail>();
        }
        public int StudentExamId { get; set; }
        public int QuestionId { get; set; }
        public string Answers { get; set; }
        public int? Marks { get; set; }
        public virtual StudentExam StudentExamIdNavigation { get; set; }
        public virtual Question QuestionIdNavigation { get; set; }
        public virtual ICollection<StudentExamQuestionAnswerDetail> StudentExamQuestionAnswerDetailCollection { get; set; }

    }
}
