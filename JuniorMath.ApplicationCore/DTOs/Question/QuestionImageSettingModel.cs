using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.Question
{
    public class QuestionImageSettingModel : IResultable<Entities.QuestionAggregate.QuestionImageSetting, QuestionImageSettingModel>
    {
        public int QuestionImageSettingId { get; set; }
        public string ImageName { get; set; }
        public int ImageType { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public Expression<Func<QuestionImageSetting, QuestionImageSettingModel>> CreateResult()
        {
            return m => new QuestionImageSettingModel
            {
                QuestionImageSettingId = m.Id,
                ImageName = m.ImageName,
                Description = m.Description,
                ImageType = m.ImageType,
                Active = m.Active
            };
        }

        public static implicit operator QuestionImageSettingModel(Entities.QuestionAggregate.QuestionImageSetting source)
        {
            if (source != null)
            {
                return new QuestionImageSettingModel
                {
                    QuestionImageSettingId = source.Id,
                    ImageName = source.ImageName,
                    Description = source.Description,
                    ImageType = source.ImageType,
                    Active = source.Active
                };
            }

            return null;
        }

        public static implicit operator Entities.QuestionAggregate.QuestionImageSetting(QuestionImageSettingModel source)
        {
            if (source != null)
            {
                return new Entities.QuestionAggregate.QuestionImageSetting
                {
                    Id = source.QuestionImageSettingId,
                    ImageName = source.ImageName,
                    Description = source.Description,
                    ImageType = source.ImageType,
                    Active = source.Active
                };
            }

            return null;
        }
    }
}
