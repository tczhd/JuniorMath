using System;
using System.Collections.Generic;
using System.Text;
using StudentAggregate = JuniorMath.ApplicationCore.Entities.StudentAggregate;

namespace JuniorMath.ApplicationCore.DTOs.StudentExam.Submit
{
    public class StudentExamSubmitModel
    {
        public int ExamId { get; set; }
        public int SubmittedBy { get; set; }
        public DateTime SubmitDate { get; set; }
        public int StudentExamId { get; set; }
        public int TotalMarks { get; set; }
        public List<StudentExamQuestionAnswerSubmitModel> Questions { get; set; }

        public static implicit operator StudentAggregate.StudentExam(StudentExamSubmitModel source)
        {
            return new StudentAggregate.StudentExam
            {
                EaxmId = source.ExamId,
                SubmittedBy = source.SubmittedBy,
                Submitted = true,
                SubmittedDate = source.SubmitDate
            };
        }
    }
}
