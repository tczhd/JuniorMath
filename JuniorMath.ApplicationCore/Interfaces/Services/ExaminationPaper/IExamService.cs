using JuniorMath.ApplicationCore.DTOs.StudentExaminationPaperModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper
{
    public interface IExamService
    {
        List<StudentExamModel> GetStudentExamModel(int studentSiteUserId);
    }
}
