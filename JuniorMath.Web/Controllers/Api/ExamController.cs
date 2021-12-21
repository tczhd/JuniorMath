using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.DTOs.User;
using JuniorMath.ApplicationCore.Interfaces.Services.ExaminationPaper;
using JuniorMath.Web.Models.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JuniorMath.Web.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
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

        // GET: api/<ExamController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<ExamController>
        [HttpPost]
        public IActionResult Post([FromBody] ExamRequestModel exam)
        {
            exam.SiteUserId = _userContext.SiteUserId;
            exam.SubmitDate = DateTime.Now;


            return Json(exam);
        }

    }
}
