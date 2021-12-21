using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.QuestionAggregate
{
    public class QuestionDetail : BaseEntity
    {
        public QuestionDetail()
        {
            StudentExamQuestionAnswerDetailCollection = new HashSet<StudentExamQuestionAnswerDetail>();
        }
        public int QuestionId { get; set; }
        public int QuestionImageSettingId { get; set; }
        public int Count { get; set; }
        public int Marks { get; set; }
        public string GroupName { get; set; }
        public virtual Question QuestionIdNavigation { get; set; }
        public virtual QuestionImageSetting QuestionImageSettingIdNavigation { get; set; }
        public virtual ICollection<StudentExamQuestionAnswerDetail> StudentExamQuestionAnswerDetailCollection { get; set; }
    }

}
