using JuniorMath.ApplicationCore.DTOs.Exam;
using JuniorMath.ApplicationCore.DTOs.StudentExam;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper
{
    public interface IExamService
    {
        List<ExamModel> GetExams(bool? active);
        List<StudentExamModel> GetStudentExams(int studentSiteUserId);

        ExamModel GetExam(int examId);
    }
}
