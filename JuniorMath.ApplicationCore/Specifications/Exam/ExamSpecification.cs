using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ExamAggregate = JuniorMath.ApplicationCore.Entities.ExamAggregate;

namespace JuniorMath.ApplicationCore.Specifications.Exam
{
    public class ExamSpecification : BaseSpecification<ExamAggregate.Exam>
    {
        public ExamSpecification() : base()
        {
            AddInclude(b => b.CreatedByNavigation);
            AddInclude(b => b.QuestionCollection);
            AddInclude(b => b.StudentExamCollection);
            AddInclude($"{nameof(ExamAggregate.Exam.QuestionCollection)}.{nameof(Question.QuestionDetailCollection)}");
        }

        public void AddStatus(bool? Active)
        {
            if (Active != null)
                AddCriteria(q => q.Active == Active);
        }

        public void AddExamId(int examId)
        {
            AddCriteria(q => q.Id == examId);
        }
    }
}
