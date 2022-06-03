using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.DTOs.Exam;
using JuniorMath.ApplicationCore.DTOs.StudentExam;
using JuniorMath.ApplicationCore.DTOs.StudentExam.Submit;
using JuniorMath.ApplicationCore.DTOs.User;
using JuniorMath.ApplicationCore.Entities.ExamAggregate;
using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Enums;
using JuniorMath.ApplicationCore.Interfaces.Repository;
using JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper;
using JuniorMath.ApplicationCore.Interfaces.Services.Utiliites;
using JuniorMath.ApplicationCore.Services.Utiliites;
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
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<QuestionDetail> _questionDetailRepository;
        private readonly IUtilityService _utilityService;
        public ExamService(IRepository<Exam> examRepository, IRepository<Question> questionRepository,
            IRepository<QuestionDetail> questionDetailRepository, IRepository<StudentExam> studentExamRepository,
            IUtilityService utilityService)
        {
            _examRepository = examRepository;
            _studentExamRepository = studentExamRepository;
            _questionRepository = questionRepository;
            _questionDetailRepository = questionDetailRepository;
            _utilityService = utilityService;
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

        public StudentExamModel GetStudentExam(int studentExamId)
        {
            var examSpecification = new StudentExamSpecification();
            examSpecification.AddStudentExamId(studentExamId);

            var data = _studentExamRepository.GetSingleBySpec(examSpecification);

            return (StudentExamModel)data;
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

        public bool SubmitNewExamAsync(int creadteBy, string examName, string description, int questions)
        {
            try
            {
                var imageSettings = _utilityService.GetQuestionImageSettingModels();
                var newExam = new ExamModel()
                {
                    Name = examName,
                    Description = description,
                    CreatedDate = DateTime.Now,
                    CreatedBy = creadteBy,
                    Active = true
                };
                var createdExam = _examRepository.Add(newExam);

                var newQuestions = new List<QuestionModel>();
                for (int i = 0; i < questions; i++)
                {
                    var question = new QuestionModel()
                    {
                        ExamId = createdExam.Id,
                        Name = $"Question {i + 1}",
                        QuestionType = (int)QuestionType.ImageCount,
                        Description = QuestionType.ImageCount.ToString(),
                        CorrectAnswers = string.Empty,
                        Marks = 100,
                        CreatedDate = DateTime.Now,
                        CreatedBy = creadteBy,
                        Active = true
                    };

                    
                    var data = _questionRepository.Add(question);
                    newQuestions.Add(data);
                }

                Random rand = new Random();

                foreach (var question in newQuestions)
                {
                    int questionDetailCount = rand.Next(3, 10);
                    var totalMark = 100;
                    var eachQuestionMark = totalMark / questionDetailCount;
                    for (int i = 0; i < questionDetailCount; i++)
                    {
                        int imagesCount = rand.Next(4, 25);
                        int imageId = imageSettings[ rand.Next(imageSettings.Count())].QuestionImageSettingId;
                        

                         var questionDetail = new QuestionDetailModel() {
                            QuestionId = question.QuestionId,
                            QuestionImageSettingId = imageId,
                            Count = imagesCount,
                            Marks = (i == questionDetailCount -1 )? totalMark:eachQuestionMark,
                            GroupName = "Group1"
                         };

                        _questionDetailRepository.AddOnly(questionDetail);
                        totalMark -= eachQuestionMark;
                    }
                }

                _questionDetailRepository.SaveAll();

                return true;
            }
            catch (Exception ex)
            {
                return false;
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

                studentExam.TotalMarks += studentQuestionAnswer.Marks ?? 0;
            }

            return studentExam;
        }
    }
}
