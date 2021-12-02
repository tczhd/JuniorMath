using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.StudentAggregate
{
    public partial class StudentExaminationPaperQuestionAnswer : BaseEntity
    {
        public StudentExaminationPaperQuestionAnswer()
        {
        }
        public int StudentExaminationPaperId { get; set; }
        public int QuestionId { get; set; }
        public string Answers { get; set; }
        public int? Marks { get; set; }
        public virtual StudentExaminationPaper StudentExaminationPaperIdNavigation { get; set; }
        public virtual Question QuestionIdNavigation { get; set; }
    }
}
