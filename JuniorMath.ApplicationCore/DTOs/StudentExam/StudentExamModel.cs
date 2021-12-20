using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.StudentExam
{
    public class StudentExamModel : IResultable<Entities.StudentAggregate.StudentExam, StudentExamModel>
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public string ExamDescription { get; set; }
        public string Teacher { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SubmittedBy { get; set; }
        public string SubmittedName { get; set; }
        public bool Active { get; set; }
        public int? TotalMarks { get; set; }
        public bool Submitted { get; set; }
        public DateTime SubmittedDate { get; set; }
        public List<StudentExamQuestionAnswerModel>
            StudentExaminationPaperQuestionAnswers
        { get; set; }

        public Expression<Func<Entities.StudentAggregate.StudentExam, StudentExamModel>> CreateResult()
        {
            return m => new StudentExamModel
            {
                Id = m.Id,
                ExamId = m.EaxmId,
                ExamName = m.ExamIdNavigation.Name,
                ExamDescription = m.ExamIdNavigation.Description,
                Teacher = m.ExamIdNavigation.CreatedByNavigation.FirstName + " " + m.ExamIdNavigation.CreatedByNavigation.LastName,
                Notes = m.Notes,
                SubmittedBy = m.SubmittedBy,
                SubmittedName = m.SubmittedByNavigation.FirstName +  " " + m.SubmittedByNavigation.LastName,
                TotalMarks = m.TotalMarks,
                Submitted = m.Submitted,
                SubmittedDate = m.SubmittedDate
            };
        }

        public static implicit operator StudentExamModel(Entities.StudentAggregate.StudentExam source)
        {
            if (source != null)
            {
                return new StudentExamModel
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

        public static implicit operator Entities.StudentAggregate.StudentExam(StudentExamModel source)
        {
            if (source != null)
            {
                return new Entities.StudentAggregate.StudentExam
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
