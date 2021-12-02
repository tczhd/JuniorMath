using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.ExaminationPaperAggregate
{
    public partial class ExaminationPaperQuestion : BaseEntity
    {
        public ExaminationPaperQuestion()
        {
        }
        public int PaperId { get; set; }
        public int  QuestionId { get; set; }

        public virtual ExaminationPaper PaperIdNavigation { get; set; }

        public virtual Question QuestionIdNavigation { get; set; }
    }
}
