using JuniorMath.ApplicationCore.DTOs.Exam;
using JuniorMath.ApplicationCore.DTOs.StudentExam;
using JuniorMath.Web.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.ViewModels.Exam
{
    public class AddExamViewModel
    {
        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }
        [Display(Name = "Question Total")]
        public int QuestionTotal { get; set; }

        [Display(Name = "Description")]
        public string Description
        {
            get; set;
        }
    }
}
