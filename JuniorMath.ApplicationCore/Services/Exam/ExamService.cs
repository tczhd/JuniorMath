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
                var exam = _examRepository.GetById(studentExamSubmitModel.ExamId);

                var studentExam = studentExamSubmitModel;
                foreach (var question in studentExam.Questions)
                {
                    foreach (var questionDetail in question.QuestionDetails)
                    { 
                        
                    }
                }
                //var invoice = (Invoice)invoiceModel;
                //if (invoiceModel.ReOccouring)
                //{
                //    var patient = _patientRepository.GetById(invoice.PatientId);
                //    patient.SubscriptionExpireDate = invoice.InvoiceDate.AddYears(1);
                //    patient.UpdatedDateUtc = DateTime.UtcNow;
                //    _patientRepository.UpdateOnly(patient);
                //}

                //_invoiceRepository.AddOnly(invoice);

                //_invoiceRepository.SaveAll();

                //invoiceModel.InvoiceId = invoice.Id;
                //invoiceModel.DisplayId = invoice.DisplayId;

                return new StudentExamSubmitModel();
            }
            catch (Exception ex)
            {
                throw new Exception("Submit student exam failed: " + ex.Message);
            }
        }
    }
}
