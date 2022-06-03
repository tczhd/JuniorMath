using JuniorMath.ApplicationCore.DTOs.Exam;
using JuniorMath.ApplicationCore.DTOs.StudentExam;
using JuniorMath.ApplicationCore.DTOs.StudentExam.Submit;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper
{
    public interface IExamService
    {
        ExamModel GetExam(int examId);
        List<ExamModel> GetExams(bool? active);
        List<StudentExamModel> GetStudentExams(int studentSiteUserId);
        StudentExamModel GetStudentExam(int studentExamId);
        StudentExamSubmitModel SubmitStudentExamAsync(StudentExamSubmitModel studentExamSubmitModel);
        bool SubmitNewExamAsync(int creadteBy, string examName, string description, int questions);
    }
}
