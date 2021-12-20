using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using JuniorMath.ApplicationCore.Entities.ExamAggregate;
using System.Linq;

namespace JuniorMath.ApplicationCore.DTOs.Exam
{
    public class ExamModel : IResultable<Entities.ExamAggregate.Exam, ExamModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string Teacher { get; set; }
        public bool Active { get; set; }
        public List<QuestionModel> Questions { get; set; }

        public Expression<Func<Entities.ExamAggregate.Exam, ExamModel>> CreateResult()
        {
            return m => new ExamModel
            {
                Id = m.Id,
                Name= m.Name,
                Description = m.Description,
                CreatedDate = m.CreatedDate,
                CreatedBy = m.CreatedBy,
                Teacher = m.CreatedByNavigation.FirstName + " " + m.CreatedByNavigation.LastName,
                Active = m.Active,
                Questions = m.QuestionCollection.Select(p => (QuestionModel)p).ToList()
            };
        }

        public static implicit operator ExamModel(Entities.ExamAggregate.Exam source)
        {
            if (source != null)
            {
                return new ExamModel
                {
                    Id = source.Id,
                    Name = source.Name,
                    Description = source.Description,
                    CreatedDate = source.CreatedDate,
                    CreatedBy = source.CreatedBy,
                    Active = source.Active,
                    Teacher = source.CreatedByNavigation.FirstName + " " + source.CreatedByNavigation.LastName,
                    Questions = source.QuestionCollection.Select(p => (QuestionModel)p).ToList()
                };
            }

            return null;
        }

        public static implicit operator Entities.ExamAggregate.Exam(ExamModel source)
        {
            if (source != null)
            {
                return new Entities.ExamAggregate.Exam
                {
                    Id = source.Id,
                    Name = source.Name,
                    Description = source.Description,
                    CreatedDate = source.CreatedDate,
                    CreatedBy = source.CreatedBy,
                    Active = source.Active
                };
            }

            return null;
        }
    }
}
