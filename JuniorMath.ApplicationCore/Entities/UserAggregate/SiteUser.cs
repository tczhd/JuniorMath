using JuniorMath.ApplicationCore.Entities.CommonAggregate;
using JuniorMath.ApplicationCore.Entities.ExamAggregate;
using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JuniorMath.ApplicationCore.Entities.UserAggregate
{
    public partial class SiteUser : BaseEntity
    {
        public SiteUser()
        {
            AddressCreatedByCollection = new HashSet<Address>();
            AddressUpdatedByCollection = new HashSet<Address>();
            QuestionCreatedByCollection = new HashSet<Question>();
            ExamCreatedByCollection = new HashSet<Exam>();
            StudentExamCreatedByCollection = new HashSet<StudentExam>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [StringLength(450)]
        public string UserId { get; set; }
        public int SiteUserLevelId { get; set; }
        public bool Active { get; set; }
        public string Note { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual SiteUserLevel SiteUserLevel { get; set; }
        public virtual ICollection<Address> AddressCreatedByCollection { get; set; }
        public virtual ICollection<Address> AddressUpdatedByCollection { get; set; }
        public virtual ICollection<Question> QuestionCreatedByCollection { get; set; }
        public virtual ICollection<StudentExamQuestionAnswer> StudentExamQuestionAnswerCollection { get; set; }
        public virtual ICollection<Exam> ExamCreatedByCollection { get; set; }
        public virtual ICollection<StudentExam> StudentExamCreatedByCollection { get; set; }
    }
}
