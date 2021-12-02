using JuniorMath.ApplicationCore.Entities.ExaminationPaperAggregate;
using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.QuestionAggregate
{
    public partial class Question : BaseEntity
    {
        public Question()
        {
            PaperQuestionAnswerQuestionIdNavigation = new HashSet<StudentExaminationPaperQuestionAnswer>();
            ExaminationPaperQuestionIdNavigation = new HashSet<ExaminationPaperQuestion>();
        }
        public string Name { get; set; }
        public int QuestionType { get; set; }
        public string Description { get; set; }
        public string ImageOrders { get; set; }
        public string CorrectAnswers { get; set; }
        public int Marks { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public virtual SiteUser CreatedByNavigation { get; set; }
        public virtual ICollection<StudentExaminationPaperQuestionAnswer> PaperQuestionAnswerQuestionIdNavigation { get; set; }
        public virtual ICollection<ExaminationPaperQuestion> ExaminationPaperQuestionIdNavigation { get; set; }
    }
}
