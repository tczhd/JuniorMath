using JuniorMath.ApplicationCore.DTOs.StudentExam.Submit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JuniorMath.Web.Models.Exam
{
    [DataContract(Name = "question")]
    public class QuestionRequestModel
    {
        [DataMember(Name = "question_id")]
        public int QuestionId { get; set; }
        [DataMember(Name = "student_exam_id")]
        public int StudentExamId { get; set; }
        [DataMember(Name = "marks")]
        public int marks { get; set; }
        [DataMember(Name = "question_details")]
        public List<QuestionDetailRequestModel> QuestionDetails { get; set; }

        public static implicit operator StudentExamQuestionAnswerSubmitModel(QuestionRequestModel source)
        {
            return new StudentExamQuestionAnswerSubmitModel
            {
                QuestionId = source.QuestionId,
                QuestionDetails = source.QuestionDetails
                .Select(p => (StudentExamQuestionAnswerDetailSubmitModel)p).ToList()

            };
        }
    }
}
