using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Specifications.ExaminationPaper
{
    public class ExamSpecification : BaseSpecification<StudentExam>
    {
        public ExamSpecification() : base()
        {
            AddInclude(b => b.SubmittedByNavigation);
            AddInclude(b => b.ExamIdNavigation);
        }

        public void AddStudentSiteUserId(int siteUserId)
        {
            AddCriteria(q => q.SubmittedBy == siteUserId);
        }
    }
}
