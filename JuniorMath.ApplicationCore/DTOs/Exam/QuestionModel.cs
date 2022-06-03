using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace JuniorMath.ApplicationCore.DTOs.Exam
{
    public class QuestionModel : IResultable<Entities.QuestionAggregate.Question, QuestionModel>
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuestionType { get; set; }
        public string CorrectAnswers { get; set; }
        public int Marks { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public int ExamId { get; set; }
        public List<QuestionDetailModel> QuestionDetail { get; set; }
    public Expression<Func<Entities.QuestionAggregate.Question, QuestionModel>> CreateResult()
        {
            return m => new QuestionModel
            {
                CorrectAnswers = m.CorrectAnswers,
                Active = m.Active,
                QuestionId = m.Id,
                QuestionType = m.QuestionType,
                CreatedBy = m.CreatedBy,
                CreatedDate = m.CreatedDate,
                Description = m.Description,
                ExamId = m.ExamId,
                Marks = m.Marks,
                Name = m.Name,
                QuestionDetail = m.QuestionDetailCollection.Select(p => (QuestionDetailModel)p).ToList()
            };
        }

        public static implicit operator QuestionModel(Entities.QuestionAggregate.Question source)
        {
            if (source != null)
            {
                return new QuestionModel
                {
                    CorrectAnswers = source.CorrectAnswers,
                    Active = source.Active,
                    QuestionId = source.Id,
                    CreatedBy = source.CreatedBy,
                    QuestionType = source.QuestionType,
                    CreatedDate = source.CreatedDate,
                    Description = source.Description,
                    ExamId = source.ExamId,
                    Marks = source.Marks,
                    Name = source.Name,
                    QuestionDetail = source.QuestionDetailCollection.Select(p => (QuestionDetailModel)p).ToList()
                };
            }

            return null;
        }

        public static implicit operator Entities.QuestionAggregate.Question(QuestionModel source)
        {
            if (source != null)
            {
                return new Entities.QuestionAggregate.Question
                {
                    CorrectAnswers = source.CorrectAnswers,
                    Active = source.Active,
                    Id = source.QuestionId,
                    QuestionType = source.QuestionType,
                    CreatedBy = source.CreatedBy,
                    CreatedDate = source.CreatedDate,
                    Description = source.Description,
                    ExamId = source.ExamId,
                    Marks = source.Marks,
                    Name = source.Name
                };
            }

            return null;
        }
    }
}
