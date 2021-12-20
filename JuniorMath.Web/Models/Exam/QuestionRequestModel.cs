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
        [DataMember(Name = "question_details")]
        public List<QuestionDetailRequestModel> QuestionDetails { get; set; }
    }
}
