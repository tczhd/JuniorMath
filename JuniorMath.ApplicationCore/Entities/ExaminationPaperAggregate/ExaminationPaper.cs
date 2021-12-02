using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.ExaminationPaperAggregate
{
    public partial class ExaminationPaper : BaseEntity
    {
        public ExaminationPaper()
        {
            StudentExaminationPaperIdNavigation = new HashSet<StudentExaminationPaper>();
            ExaminationPaperQuestionPaperIdNavigation = new HashSet<ExaminationPaperQuestion>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public virtual SiteUser CreatedByNavigation { get; set; }
        public virtual ICollection<StudentExaminationPaper> StudentExaminationPaperIdNavigation { get; set; }
        public virtual ICollection<ExaminationPaperQuestion> ExaminationPaperQuestionPaperIdNavigation { get; set; }
    }
}
