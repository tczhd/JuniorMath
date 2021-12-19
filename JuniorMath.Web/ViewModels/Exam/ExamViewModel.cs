using JuniorMath.ApplicationCore.DTOs.ExaminationPaperModel;
using JuniorMath.ApplicationCore.DTOs.StudentExaminationPaperModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.ViewModels.Exam
{
    public class ExamViewModel
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
        public string CreatedBy { get; set; }
        [Display(Name = "Status")]
        public bool Active { get; set; }

        public static implicit operator ExamViewModel(StudentExamModel source)
        {
            return new ExamViewModel
            {
                ExamId = source.Id,
                CreatedBy = source.SubmittedBy.ToString(),
                Active = source.Active,
                CreateDate = source.CreatedDate,
                Description = source.ExamDescription,
                ExamName = source.ExamName
            };
        }
    }
}
