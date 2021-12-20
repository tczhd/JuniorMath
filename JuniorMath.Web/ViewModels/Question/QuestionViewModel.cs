using JuniorMath.ApplicationCore.DTOs.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.ViewModels.Question
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CorrectAnswers { get; set; }
        public int Marks { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public int ExamId { get; set; }
        public List<QuestionDetailViewModel> QuestionDetail { get; set; }

        public static implicit operator QuestionViewModel(QuestionModel source)
        {
            if (source != null)
            {
                return new QuestionViewModel
                {
                    CorrectAnswers = source.CorrectAnswers,
                    Active = source.Active,
                    QuestionId = source.QuestionId,
                    CreatedBy = source.CreatedBy,
                    CreatedDate = source.CreatedDate,
                    Description = source.Description,
                    ExamId = source.ExamId,
                    Marks = source.Marks,
                    Name = source.Name,
                    QuestionDetail = source.QuestionDetail.Select(p => (QuestionDetailViewModel)p).ToList()
                };
            }

            return null;
        }
    }
}