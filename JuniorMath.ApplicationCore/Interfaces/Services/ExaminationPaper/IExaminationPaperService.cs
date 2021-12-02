using JuniorMath.ApplicationCore.DTOs.StudentExaminationPaperModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper
{
    public interface IExaminationPaperService
    {
        List<StudentExaminationPaperModel> GetStudentExaminationPaperModel(int studentSiteUserId);
    }
}
