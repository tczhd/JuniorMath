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
        public int ExaminationPaperId { get; set; }
        public int  QuestionId { get; set; }
    }
}
