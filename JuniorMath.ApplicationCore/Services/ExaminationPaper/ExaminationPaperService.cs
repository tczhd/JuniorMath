using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.DTOs.StudentExaminationPaperModel;
using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Interfaces.Repository;
using JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper;
using JuniorMath.ApplicationCore.Specifications.ExaminationPaper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuniorMath.ApplicationCore.Services.ExaminationPaper
{
    public class ExaminationPaperService : IExaminationPaperService
    {
        private readonly IRepository<StudentExam> _studentExaminationPaperRepository;
        private readonly UserHandler _userHandler;

        public ExaminationPaperService(IRepository<StudentExam> studentExaminationPaperRepository, UserHandler userHandler)
        {
            _studentExaminationPaperRepository = studentExaminationPaperRepository;
            _userHandler = userHandler;
            var userContext = _userHandler.GetUserContext();
            if (userContext != null)
            {
            }
        }

        public List<StudentExaminationPaperModel> GetStudentExaminationPaperModel(int studentSiteUserId)
        {
            var examinationPaperSpecification = new ExaminationPaperSpecification();
            examinationPaperSpecification.AddStudentSiteUserId(studentSiteUserId);

            var data = _studentExaminationPaperRepository.List(examinationPaperSpecification);

            var result = data.Select(p => (StudentExaminationPaperModel)p).ToList();

            return result;
        }
    }
}
