using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.Controllers
{
    public class ExamController : Controller
    {
        [Authorize]
        [Route("Exam")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
