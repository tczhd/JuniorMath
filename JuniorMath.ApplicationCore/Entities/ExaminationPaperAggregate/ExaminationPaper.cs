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
            ExaminationPaperCreatedByNavigation = new HashSet<StudentExaminationPaper>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public virtual SiteUser CreatedByNavigation { get; set; }
        public virtual ICollection<StudentExaminationPaper> ExaminationPaperCreatedByNavigation { get; set; }
        
    }
}
