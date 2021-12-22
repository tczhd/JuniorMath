using System;
using System.Collections.Generic;
using System.Text;
using StudentAggregate = JuniorMath.ApplicationCore.Entities.StudentAggregate;
using System.Linq;
using JuniorMath.ApplicationCore.Entities.StudentAggregate;

namespace JuniorMath.ApplicationCore.DTOs.StudentExam.Submit
{
    public class StudentExamSubmitModel
    {
        public int ExamId { get; set; }
        public int SubmittedBy { get; set; }
        public bool Submitted { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int StudentExamId { get; set; }
        public int TotalMarks { get; set; }
        public List<StudentExamQuestionAnswerSubmitModel> Questions { get; set; }

        public static implicit operator StudentAggregate.StudentExam(StudentExamSubmitModel source)
        {
            return new StudentAggregate.StudentExam
            {
                EaxmId = source.ExamId,
                SubmittedBy = source.SubmittedBy,
                Submitted = source.Submitted,
                SubmittedDate = source.SubmittedDate,
                TotalMarks = source.TotalMarks,
                StudentExamQuestionAnswerCollection = source.Questions
                .Select(p => (StudentExamQuestionAnswer)p).ToList()
            };
        }

        public static implicit operator StudentExamSubmitModel( StudentAggregate.StudentExam source)
        {
            return new StudentExamSubmitModel
            {
                StudentExamId = source.Id,
                ExamId = source.EaxmId,
                SubmittedBy = source.SubmittedBy,
                Submitted = source.Submitted,
                SubmittedDate = source.SubmittedDate,
                TotalMarks = source.TotalMarks??0
            };
        }
    }
}
