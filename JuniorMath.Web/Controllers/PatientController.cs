
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using JuniorMath.ApplicationCore.Interfaces.Services.Utiliites;
//using JuniorMath.Web.Interfaces.Api;

//namespace JuniorMath.Web.Controllers
//{
//    [Authorize]
//    [Route("Patient")]
//    public class PatientController : Controller
//    {
//        private readonly IUtilityService _utilityService;
//       private readonly IPatientApiService _patientApiService;

//        public PatientController(IPatientApiService patientApiService, IUtilityService utilityService)
//        {
//            _patientApiService = patientApiService;
//            _utilityService = utilityService;
//        }

//        [Route("{view=Index}")]
//        public IActionResult Index(int id, string view)
//        {
//            if (view == "PatientForm")
//            {
//                ViewBag.ListofCountry = _utilityService.GetCountries();
//                ViewBag.ListofRegion = _utilityService.GetRegions();

//                if (id == 0)
//                {
//                    ViewData["Title"] = $"New Patient";
//                    ViewData["FormType"] = $"New Patient";
//                    ViewBag.buttonNname = "Add Patient";
//                }
//                else
//                {
//                    ViewData["Title"] = $"Edit Patient";
//                    ViewData["FormType"] = $"Edit Patient"; 
//                    ViewBag.buttonNname = "Edit Patient";

//                    var data = _patientApiService.SearchPatient(id);
//                    return View(view, data);
//                }
//            }
//            else if (view == "Index")
//            {
//                ViewData["Title"] = $"Search Patient";
//            }

//            return View(view);
//        }

//    }
//}
