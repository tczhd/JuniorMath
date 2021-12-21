using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.Exam
{
    public class QuestionDetailModel : IResultable<Entities.QuestionAggregate.QuestionDetail, QuestionDetailModel>
    {
        public int QuestionDetailId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionImageSettingId { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
        public int Marks { get; set; }
        public string GroupName { get; set; }
        public Expression<Func<Entities.QuestionAggregate.QuestionDetail, QuestionDetailModel>> CreateResult()
        {
            return m => new QuestionDetailModel
            {
                QuestionDetailId = m.Id,
                Count = m.Count,
                Marks = m.Marks,
                GroupName = m.GroupName,
                ImageName = m.QuestionImageSettingIdNavigation.ImageName,
                QuestionId = m.QuestionId,
                QuestionImageSettingId = m.QuestionImageSettingId
            };
        }

        public static implicit operator QuestionDetailModel(Entities.QuestionAggregate.QuestionDetail source)
        {
            if (source != null)
            {
                return new QuestionDetailModel
                {
                    QuestionDetailId = source.Id,
                    Count = source.Count,
                    Marks = source.Marks,
                    GroupName = source.GroupName,
                    ImageName = source.QuestionImageSettingIdNavigation.ImageName,
                    QuestionId = source.QuestionId,
                    QuestionImageSettingId = source.QuestionImageSettingId
                };
            }

            return null;
        }

        public static implicit operator Entities.QuestionAggregate.QuestionDetail(QuestionDetailModel source)
        {
            if (source != null)
            {
                return new Entities.QuestionAggregate.QuestionDetail
                {
                    Id = source.QuestionDetailId ,
                    Count = source.Count,
                    Marks = source.Marks,
                    GroupName = source.GroupName,
                    QuestionId = source.QuestionId,
                    QuestionImageSettingId = source.QuestionImageSettingId
                };
            }

            return null;
        }
    }
}
