using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.QuestionAggregate
{
    public partial class QuestionImageSetting : BaseEntity
    {
        public QuestionImageSetting()
        {
        }
        public string ImageName { get; set; }
        public int ImageType { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
