using JuniorMath.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Entities.QuestionAggregate
{
    public partial class Question : BaseEntity
    {
        public Question()
        {
        }
        public string Name { get; set; }
        public int QuestionType { get; set; }
        public string Description { get; set; }
        public string ImageOrders { get; set; }
        public string Answers { get; set; }
        public int Marks { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public virtual SiteUser CreatedByNavigation { get; set; }
    }
}
