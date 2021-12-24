using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Specifications.ExaminationPaper
{
    public class StudentExamSpecification : BaseSpecification<StudentExam>
    {
        public StudentExamSpecification() : base()
        {
            AddInclude(b => b.SubmittedByNavigation);
            AddInclude(b => b.ExamIdNavigation);
        }

        public void AddStudentExamId(int studentExamId)
        {
            AddCriteria(q => q.Id == studentExamId);
        }
        public void AddStudentSiteUserId(int siteUserId)
        {
            AddCriteria(q => q.SubmittedBy == siteUserId);
        }
    }
}
