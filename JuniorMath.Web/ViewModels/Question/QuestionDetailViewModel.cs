using JuniorMath.ApplicationCore.DTOs.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.ViewModels.Question
{
    public class QuestionDetailViewModel
    {
        public int QuestionDetailId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionImageSettingId { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
        public string GroupName { get; set; }

        public static implicit operator QuestionDetailViewModel(QuestionDetailModel source)
        {
            if (source != null)
            {
                return new QuestionDetailViewModel
                {
                    QuestionDetailId = source.QuestionDetailId,
                    Count = source.Count,
                    GroupName = source.GroupName,
                    ImageName = source.ImageName,
                    QuestionId = source.QuestionId,
                    QuestionImageSettingId = source.QuestionImageSettingId
                };
            }

            return null;
        }
    }
}
