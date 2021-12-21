using JuniorMath.ApplicationCore.DTOs.StudentExam.Submit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JuniorMath.Web.Models.Exam
{
    [DataContract(Name = "exam")]
    public class ExamRequestModel
    {
        [DataMember(Name = "exam_id")]
        public int ExamId { get; set; }
        [DataMember(Name = "site_user_id")]
        public int SiteUserId { get; set; }
        [DataMember(Name = "submit_date")]
        public DateTime SubmitDate { get; set; }
        [DataMember(Name = "student_exam_id")]
        public int StudentExamId { get; set; }
        [DataMember(Name = "marks")]
        public int marks { get; set; }
        [DataMember(Name = "questions")]
        public List<QuestionRequestModel> Questions { get; set; }

        public static implicit operator StudentExamSubmitModel(ExamRequestModel source)
        {
            return new StudentExamSubmitModel
            {
                ExamId = source.ExamId,
                SubmittedBy = source.SiteUserId,
                Questions = source.Questions
                .Select(p => (StudentExamQuestionAnswerSubmitModel)p).ToList()
            };
        }

        public static implicit operator ExamRequestModel(StudentExamSubmitModel source)
        {
            return new ExamRequestModel
            {
                ExamId = source.ExamId,
                SiteUserId = source.SubmittedBy,
                marks = source.TotalMarks,
                StudentExamId = source.StudentExamId,
                SubmitDate = source.SubmitDate
           
            };
        }
    }
}
