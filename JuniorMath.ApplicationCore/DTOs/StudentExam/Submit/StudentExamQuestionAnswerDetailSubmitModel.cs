using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.StudentExam.Submit
{
    public class StudentExamQuestionAnswerDetailSubmitModel
    {
        public int StudentExamQuestionAnswerId { get; set; }
        public int QuestionDetailId { get; set; }
        public int? QuestionDetailAnswerCount { get; set; }

        public static implicit operator StudentExamQuestionAnswerDetail(StudentExamQuestionAnswerDetailSubmitModel source)
        {
            return new StudentExamQuestionAnswerDetail
            {
                QuestionDetailId = source.QuestionDetailId,
                AnswerCounts = source.QuestionDetailAnswerCount,
                StudentExamQuestionAnswerId = source.StudentExamQuestionAnswerId
            };
        }
    }
}
