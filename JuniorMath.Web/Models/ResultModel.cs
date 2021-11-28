using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace JuniorMath.Web.Models
{
    [DataContract(Name = "result_model")]
    public class ResultModel
    {
        [DataMember(Name = "success")]
        public bool Success{ get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
