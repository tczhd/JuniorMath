using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using JuniorMath.ApplicationCore.Entities.ExamAggregate;

namespace JuniorMath.ApplicationCore.DTOs.ExaminationPaperModel
{
    public class ExamModel : IResultable<Exam, ExamModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }

        public Expression<Func<Exam, ExamModel>> CreateResult()
        {
            return m => new ExamModel
            {
                Id = m.Id,
                Name= m.Name,
                Description = m.Description,
                CreatedDate = m.CreatedDate,
                CreatedBy = m.CreatedBy,
                Active = m.Active
            };
        }

        public static implicit operator ExamModel(Exam source)
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
                    Active = source.Active
                };
            }

            return null;
        }

        public static implicit operator Exam(ExamModel source)
        {
            if (source != null)
            {
                return new Exam
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
