using JuniorMath.ApplicationCore.Domain.User;
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

        public ExamController(IExamService examService, UserHandler userHandler)
        {
            _examService = examService;
            _userHandler = userHandler;
        }
        public IActionResult Index()
        {
            var userContext = _userHandler.GetUserContext();

            ViewData["Title"] = $"Exam List";

            var studentExams = _examService.GetStudentExamModel(userContext.SiteUserId);

            var data = studentExams.Select(p => (ExamViewModel)p).ToList();
            return View(data);
        }
    }
}
