using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JuniorMath.Web.Models.Exam
{
    [DataContract(Name = "question_detail")]
    public class QuestionDetailRequestModel
    {
        [DataMember(Name = "question_detail_id")]
        public int QuestionDetailId { get; set; }
        [DataMember(Name = "question_detail_answer")]
        public string QuestionDetailAnswer { get; set; }
    }
}
