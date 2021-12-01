using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using JuniorMath.ApplicationCore.Entities.ExaminationPaperAggregate;

namespace JuniorMath.ApplicationCore.DTOs.ExaminationPaperModel
{
    public class ExaminationPaperModel : IResultable<ExaminationPaper, ExaminationPaperModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }

        public Expression<Func<ExaminationPaper, ExaminationPaperModel>> CreateResult()
        {
            return m => new ExaminationPaperModel
            {
                Id = m.Id,
                Name= m.Name,
                Description = m.Description,
                CreatedDate = m.CreatedDate,
                CreatedBy = m.CreatedBy,
                Active = m.Active
            };
        }

        public static implicit operator ExaminationPaperModel(ExaminationPaper source)
        {
            if (source != null)
            {
                return new ExaminationPaperModel
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

        public static implicit operator ExaminationPaper(ExaminationPaperModel source)
        {
            if (source != null)
            {
                return new ExaminationPaper
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
