using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.ViewModels.Exam
{
    public class ExamGroupViewModel
    {
        public List<ExamViewModel> Exams { get; set; }

        public List<StudentExamViewModel> StudentExams { get; set; }

        public ExamGroupViewModel()
        {
            Exams = new List<ExamViewModel>();
            StudentExams = new List<StudentExamViewModel>();
        }
    }
}
