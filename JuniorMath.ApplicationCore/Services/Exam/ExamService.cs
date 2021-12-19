using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.DTOs.StudentExaminationPaperModel;
using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Interfaces.Repository;
using JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper;
using JuniorMath.ApplicationCore.Specifications.ExaminationPaper;
using System.Collections.Generic;
using System.Linq;

namespace JuniorMath.ApplicationCore.Services.ExaminationPaper
{
    public class ExamService : IExamService
    {
        private readonly IRepository<StudentExam> _studentExamRepository;
        private readonly UserHandler _userHandler;

        public ExamService(IRepository<StudentExam> studentExamRepository, UserHandler userHandler)
        {
            _studentExamRepository = studentExamRepository;
            _userHandler = userHandler;
            var userContext = _userHandler.GetUserContext();
            if (userContext != null)
            {
            }
        }

        public List<StudentExamModel> GetStudentExamModel(int studentSiteUserId)
        {
            var examSpecification = new ExamSpecification();
            examSpecification.AddStudentSiteUserId(studentSiteUserId);

            var data = _studentExamRepository.List(examSpecification);

            var result = data.Select(p => (StudentExamModel)p).ToList();

            return result;
        }
    }
}
