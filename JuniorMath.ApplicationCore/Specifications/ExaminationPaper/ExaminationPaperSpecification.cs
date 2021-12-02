using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Specifications.ExaminationPaper
{
    public class ExaminationPaperSpecification : BaseSpecification<StudentExaminationPaper>
    {
        public ExaminationPaperSpecification() : base()
        {
            AddInclude(b => b.SiteUserIdNavigation);
            AddInclude(b => b.CreatedByNavigation);
            AddInclude(b => b.PaperIdNavigation);
        }

        public void AddStudentSiteUserId(int siteUserId)
        {
            AddCriteria(q => q.SiteUserId == siteUserId);
        }
    }
}
