using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.StudentExaminationPaperModel
{
    public class StudentExaminationPaperModel : IResultable<StudentExam, StudentExaminationPaperModel>
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public string ExamDescription { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SubmittedBy { get; set; }
        public bool Active { get; set; }
        public int? TotalMarks { get; set; }
        public bool Submitted { get; set; }
        public DateTime SubmittedDate { get; set; }
        public List<StudentExamQuestionAnswerModel>
            StudentExaminationPaperQuestionAnswers
        { get; set; }

        public Expression<Func<StudentExam, StudentExaminationPaperModel>> CreateResult()
        {
            return m => new StudentExaminationPaperModel
            {
                Id = m.Id,
                ExamId = m.EaxmId,
                ExamName = m.ExamIdNavigation.Name,
                ExamDescription = m.ExamIdNavigation.Description,
                Notes = m.Notes,
                SubmittedBy = m.SubmittedBy,
                TotalMarks = m.TotalMarks,
                Submitted = m.Submitted,
                SubmittedDate = m.SubmittedDate
            };
        }

        public static implicit operator StudentExaminationPaperModel(StudentExam source)
        {
            if (source != null)
            {
                return new StudentExaminationPaperModel
                {
                    Id = source.Id,
                    ExamId = source.EaxmId,
                    ExamName = source.ExamIdNavigation.Name,
                    ExamDescription = source.ExamIdNavigation.Description,
                    Notes = source.Notes,
                    SubmittedBy = source.SubmittedBy,
                    TotalMarks = source.TotalMarks,
                    Submitted = source.Submitted,
                    SubmittedDate = source.SubmittedDate
                };
            }

            return null;
        }

        public static implicit operator StudentExam(StudentExaminationPaperModel source)
        {
            if (source != null)
            {
                return new StudentExam
                {
                    Id = source.Id,
                    EaxmId = source.ExamId,
                    Notes = source.Notes,
                    SubmittedBy = source.SubmittedBy,
                    TotalMarks = source.TotalMarks,
                    Submitted = source.Submitted,
                    SubmittedDate = source.SubmittedDate
                };
            }

            return null;
        }
    }
}
