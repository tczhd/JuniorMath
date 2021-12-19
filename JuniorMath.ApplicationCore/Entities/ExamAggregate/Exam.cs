using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.ExamAggregate
{
    public partial class Exam : BaseEntity
    {
        public Exam()
        {
            StudentExamCollection = new HashSet<StudentExam>();
            QuestionCollection = new HashSet<Question>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public virtual SiteUser CreatedByNavigation { get; set; }
        public virtual ICollection<StudentExam> StudentExamCollection { get; set; }
        public virtual ICollection<Question> QuestionCollection { get; set; }
    }
}
