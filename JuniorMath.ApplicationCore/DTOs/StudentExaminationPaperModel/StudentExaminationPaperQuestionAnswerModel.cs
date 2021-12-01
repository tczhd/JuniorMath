using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.StudentExaminationPaperModel
{
    public class StudentExaminationPaperQuestionAnswerModel
        : IResultable<StudentExaminationPaperQuestionAnswer, StudentExaminationPaperQuestionAnswerModel>
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public int QuestionType { get; set; }
        public string QuestionDescription { get; set; }
        public string ImageOrders { get; set; }
        public string CorrectAnswers { get; set; }
        public int QuestionMarks { get; set; }
        public string StudentAnswers { get; set; }
        public int? StudentMarks { get; set; }
        public Expression<Func<StudentExaminationPaperQuestionAnswer, StudentExaminationPaperQuestionAnswerModel>> CreateResult()
        {
            return m => new StudentExaminationPaperQuestionAnswerModel
            {
                Id = m.Id,
                QuestionId = m.QuestionId,
                QuestionName = m.QuestionIdNavigation.Name,
                QuestionType = m.QuestionIdNavigation.QuestionType,
                QuestionDescription = m.QuestionIdNavigation.Description,
                ImageOrders = m.QuestionIdNavigation.ImageOrders,
                CorrectAnswers = m.QuestionIdNavigation.CorrectAnswers,
                QuestionMarks = m.QuestionIdNavigation.Marks,
                StudentAnswers = m.Answers,
                StudentMarks = m.Marks
            };
        }

        public static implicit operator StudentExaminationPaperQuestionAnswerModel(StudentExaminationPaperQuestionAnswer source)
        {
            if (source != null)
            {
                return new StudentExaminationPaperQuestionAnswerModel
                {
                    Id = source.Id,
                    QuestionId = source.QuestionId,
                    QuestionName = source.QuestionIdNavigation.Name,
                    QuestionType = source.QuestionIdNavigation.QuestionType,
                    QuestionDescription = source.QuestionIdNavigation.Description,
                    ImageOrders = source.QuestionIdNavigation.ImageOrders,
                    CorrectAnswers = source.QuestionIdNavigation.CorrectAnswers,
                    QuestionMarks = source.QuestionIdNavigation.Marks,
                    StudentAnswers = source.Answers,
                    StudentMarks = source.Marks
                };
            }

            return null;
        }

        public static implicit operator StudentExaminationPaperQuestionAnswer(StudentExaminationPaperQuestionAnswerModel source)
        {
            if (source != null)
            {
                return new StudentExaminationPaperQuestionAnswer
                {
                    Id = source.Id,
                    Answers = source.StudentAnswers,
                    Marks = source.StudentMarks
                };
            }

            return null;
        }
    }
}