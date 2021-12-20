using JuniorMath.ApplicationCore.DTOs.StudentExam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.ViewModels.Exam
{
    public class StudentExamViewModel
    {
        [Display(Name = "Exam Id")]
        public int ExamId { get; set; }
        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [Display(Name = "Teacher")]
        public string Teacher { get; set; }
        [Display(Name = "Status")]
        public bool Active { get; set; }

        public static implicit operator StudentExamViewModel(StudentExamModel source)
        {
            return new StudentExamViewModel
            {
                ExamId = source.Id,
                Teacher = source.Teacher,
                Active = source.Active,
                CreateDate = source.CreatedDate,
                Description = source.ExamDescription,
                ExamName = source.ExamName
            };
        }
    }
}
