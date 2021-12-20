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
        [DataMember(Name = "questions")]
        public List<QuestionRequestModel> Questions { get; set; }
    }
}
