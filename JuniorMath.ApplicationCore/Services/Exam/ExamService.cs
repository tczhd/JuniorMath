using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.DTOs.Exam;
using JuniorMath.ApplicationCore.DTOs.StudentExam;
using JuniorMath.ApplicationCore.DTOs.StudentExam.Submit;
using JuniorMath.ApplicationCore.DTOs.User;
using JuniorMath.ApplicationCore.Entities.ExamAggregate;
using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Interfaces.Repository;
using JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper;
using JuniorMath.ApplicationCore.Specifications.Exam;
using JuniorMath.ApplicationCore.Specifications.ExaminationPaper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JuniorMath.ApplicationCore.Services.ExaminationPaper
{
    public class ExamService : IExamService
    {
        private readonly IRepository<StudentExam> _studentExamRepository;
        private readonly IRepository<Exam> _examRepository;

        public ExamService(IRepository<Exam> examRepository,
            IRepository<StudentExam> studentExamRepository)
        {
            _examRepository = examRepository;
            _studentExamRepository = studentExamRepository;
        }

        public ExamModel GetExam(int examId)
        {
            var examSpecification = new ExamSpecification();
            examSpecification.AddExamId(examId);
            var exam = _examRepository.GetSingleBySpec(examSpecification);

            return (ExamModel)exam;
        }

        public List<ExamModel> GetExams(bool? active)
        {
            var examSpecification = new ExamSpecification();
            examSpecification.AddStatus(active);

            var data = _examRepository.List(examSpecification);

            var result = data.Select(p => (ExamModel)p).ToList();

            return result;
        }

        public List<StudentExamModel> GetStudentExams(int studentSiteUserId)
        {
            var examSpecification = new StudentExamSpecification();
            examSpecification.AddStudentSiteUserId(studentSiteUserId);

            var data = _studentExamRepository.List(examSpecification);

            var result = data.Select(p => (StudentExamModel)p).ToList();

            return result;
        }

        public StudentExamSubmitModel SubmitStudentExamAsync(StudentExamSubmitModel studentExamSubmitModel)
        {
            try
            {
                var studentExamSubmit = GetStudentExamMarks(studentExamSubmitModel);

                var studentExam = (StudentExam)studentExamSubmit;

                var data = _studentExamRepository.Add(studentExam);
                _studentExamRepository.SaveAll();

                return (StudentExamSubmitModel)data;
            }
            catch (Exception ex)
            {
                throw new Exception("Submit student exam failed: " + ex.Message);
            }
        }

        private StudentExamSubmitModel GetStudentExamMarks(StudentExamSubmitModel studentExamSubmitModel)
        {
            var exam = GetExam(studentExamSubmitModel.ExamId);

            var studentExam = studentExamSubmitModel;
            studentExam.TotalMarks = 0;
            foreach (var studentQuestionAnswer in studentExam.Questions)
            {
                var quetion = exam.Questions
                    .First(p => p.QuestionId == studentQuestionAnswer.QuestionId);

                studentQuestionAnswer.SiteUserId = studentExam.SubmittedBy;
                studentQuestionAnswer.Marks = 0;
                foreach (var studentQuestionAnswerDetail in studentQuestionAnswer.QuestionDetails)
                {
                    var questionDetail = quetion.QuestionDetail
                        .First(p => p.QuestionDetailId == studentQuestionAnswerDetail.QuestionDetailId);
                    if (studentQuestionAnswerDetail.QuestionDetailAnswerCount == questionDetail.Count)
                    {
                        studentQuestionAnswer.Marks += questionDetail.Marks;
                    }
                }

                studentExam.TotalMarks += studentQuestionAnswer.Marks??0;
            }

            return studentExam;
        }
    }
}
