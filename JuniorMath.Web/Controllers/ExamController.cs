using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.DTOs.User;
using JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper;
using JuniorMath.Web.ViewModels.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.Controllers
{
    [Authorize]
    [Route("Exam")]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly UserHandler _userHandler;
        private readonly UserContext _userContext;
        public ExamController(IExamService examService, UserHandler userHandler)
        {
            _examService = examService;
            _userHandler = userHandler;
            _userContext = _userHandler.GetUserContext();
        }

        [Route("{view=Index}")]
        public IActionResult Index(int id, string view)
        {
            if (view == "Index")
            {
                ViewData["Title"] = $"Exam List";
                return GetIndexView();
            }
            else if (view == "ExamPaper")
            {
                ViewData["Title"] = $"Exam Paper";
                return GetExamPaperView(id, view);
            }
            else if (view == "ExamPaperResult")
            {
                ViewData["Title"] = $"Exam Paper Result";
                return GetStudentExamPaperView(id, view);
            }
            else if (view == "AddExam")
            {
                return View(view, null);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddExam(AddExamViewModel addExamViewModel)
        {
            var result = _examService.SubmitNewExamAsync(_userContext.SiteUserId, addExamViewModel.ExamName,
                addExamViewModel.Description, addExamViewModel.QuestionTotal);
            if (result)
            { 
                return View();
            }
            else { 
                return View(); 
            }
        }

        private ViewResult GetIndexView()
        {
            var examGroupViewModel = new ExamGroupViewModel();
            var exams = _examService.GetExams(true);
            examGroupViewModel.Exams = exams.Select(p => (ExamViewModel)p).ToList();

            var studentExams = _examService.GetStudentExams(_userContext.SiteUserId);
            examGroupViewModel.StudentExams = studentExams.Select(p => (StudentExamViewModel)p).ToList();
            var submittedExamIds = examGroupViewModel.StudentExams.Select(p => p.ExamId).ToList();
            examGroupViewModel.Exams = examGroupViewModel.Exams
                .Where(p => !submittedExamIds.Contains(p.ExamId)).ToList();

            return View(examGroupViewModel);
        }

        private ViewResult GetExamPaperView(int examId, string view)
        {
            var exam = _examService.GetExam(examId);
            var data = (ExamViewModel)exam;
            return View(view, data);
        }

        private ViewResult GetStudentExamPaperView(int studentExamId, string view)
        {
            var exam = _examService.GetStudentExam(studentExamId);
            if (exam != null)
            {
                var data = (StudentExamViewModel)exam;
                return View(view, data);
            }

            return new ViewResult();
        }
    }
}
