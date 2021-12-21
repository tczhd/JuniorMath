using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.StudentExam.Submit
{
    public class StudentExamQuestionAnswerSubmitModel
    {
        public int QuestionId { get; set; }
        public int StudentExamId { get; set; }
        public string Answers { get; set; }
        public int? Marks { get; set; }
        public int SiteUserId { get; set; }
        public List<StudentExamQuestionAnswerDetailSubmitModel> QuestionDetails { get; set; }

        public static implicit operator StudentExamQuestionAnswer(StudentExamQuestionAnswerSubmitModel source)
        {
            return new StudentExamQuestionAnswer
            {
                QuestionId = source.QuestionId,
                Answers = source.Answers,
                Marks = source.Marks,
                StudentExamId = source.StudentExamId,
            };
        }
    }
}
