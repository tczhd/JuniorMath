using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.StudentAggregate
{
    public class StudentExamQuestionAnswerDetail : BaseEntity
    {
        public StudentExamQuestionAnswerDetail()
        {
        }
        public int StudentExamQuestionAnswerId { get; set; }
        public int QuestionDetailId { get; set; }
        public int AnswerCounts { get; set; }
        public virtual StudentExamQuestionAnswer StudentExamQuestionAnswerIdNavigation { get; set; }
        public virtual QuestionDetail QuestionDetailIdNavigation { get; set; }
    }
}
