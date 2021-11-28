//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using JuniorMath.ApplicationCore.Domain.User;
//using JuniorMath.ApplicationCore.DTOs.Invoices;
//using JuniorMath.ApplicationCore.Interfaces.Base;
//using JuniorMath.ApplicationCore.Interfaces.Services.Invoices;
//using JuniorMath.ApplicationCore.Interfaces.Services.Items;
//using JuniorMath.ApplicationCore.Interfaces.Services.Payment;
//using JuniorMath.ApplicationCore.Interfaces.Services.Taxes;
//using JuniorMath.RazorClassLib.Services;
//using JuniorMath.Web.Interfaces.Api;
//using JuniorMath.Web.Models;
//using JuniorMath.Web.Models.Invoices;
//using JuniorMath.Web.Models.Patients;
//using JuniorMath.Web.Models.Payments;
//using JuniorMath.Web.ViewModels.Patients;

//namespace JuniorMath.Web.Controllers.Api
//{
//    [Authorize]
//    [Produces("application/json")]
//    [Route("api/[controller]")]
//    public class InvoiceController : Controller
//    {
//        private readonly IInvoiceService _invoiceService;
//        private readonly IItemService _itemService;
//        private readonly ITaxService _taxService;
//        private readonly IPaymentService _paymentService;
//        private readonly UserHandler _userHandler;
//        private readonly IEmailSender _emailSender;
//        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public InvoiceController(IInvoiceService invoiceService, IItemService itemService,
//            ITaxService taxService, UserHandler userHandler, IEmailSender emailSender
//            , IRazorViewToStringRenderer razorViewToStringRenderer, IPaymentService paymentService, IHttpContextAccessor httpContextAccessor)
//        {
//            _invoiceService = invoiceService;
//            _itemService = itemService;
//            _taxService = taxService;
//            _userHandler = userHandler;
//            _emailSender = emailSender;
//            _razorViewToStringRenderer = razorViewToStringRenderer;
//            _paymentService = paymentService;
//            _httpContextAccessor = httpContextAccessor;
//        }
//        private class UrlClass
//        {
//            public string showURL(IHttpContextAccessor httpcontextaccessor)
//            {
//                var request = httpcontextaccessor.HttpContext.Request;

//                var absoluteUri = string.Concat(
//                            request.Scheme,
//                            "://",
//                            request.Host.ToUriComponent(),
//                            "/img",
//                            "/sampleinvoiceimg.png");
//                return absoluteUri;
//            }
//        }
//        // GET: api/<controller>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<controller>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // GET api/<controller>/5
//        [Route("[action]/{familyId}")]
//        public IActionResult GetInitData(int familyId)
//        {
//            var userContext = _userHandler.GetUserContext();
//            var taxes = _taxService.SearchTaxesAsync(userContext.ClinicCountryId, userContext.ClinicRegionId, false);
//            var items = _itemService.SearchItems();

//            var data = new { Items = items, Taxes = taxes };
//            return Json(data);
//        }

//        // POST api/<controller>
//        [HttpPost]
//        public IActionResult Post([FromBody]InvoiceRequestModel invoice)
//        {
//            var userContext = _userHandler.GetUserContext();
//            var taxes = _taxService.SearchTaxesAsync(userContext.ClinicCountryId, userContext.ClinicRegionId, false);
//            var taxRate = taxes.Sum(p => p.TaxRate);
//            var invoiceItemModels = invoice.InvoiceItems.Select(p => new InvoiceItemModel
//            {
//                ItemId = p.ItemId,
//                Price = p.Cost,
//                Quantity = p.Quantity,
//                TaxTotal = p.Cost * p.Quantity * taxRate,
//                Subtotal = p.Cost * p.Quantity,
//                Total = p.Cost * p.Quantity * (1 + taxRate)
//            }).ToList();

//            var hasSubscriptionItems = _itemService.HasSubscriptionItems(invoiceItemModels.Select(p => p.ItemId).ToList());

//            var ticks = DateTime.Now.Ticks;
//            var guid = Guid.NewGuid().ToString();
//            var uniqueId = ticks.ToString() + '-' + guid; //guid created by combining ticks and guid

//            var invoiceModel = new InvoiceModel
//            {
//                EncryptId = uniqueId,
//                AmountPaid = 0,
//                Note = "New Invoice",
//                InvoiceStatus = 1,
//                InvoiceItems = invoiceItemModels,
//                PatientId = invoice.PatientId,
//                PaymentStatus = 1,
//                InvoiceDate = DateTime.Now,
//                DoctorId = invoice.DoctorId,
//                ClinicId = userContext.ClinicId,
//                CreatedBy = userContext.SiteUserId,
//                DiscountTotal = 0,
//                ReOccouring = hasSubscriptionItems,
//                Subtotal = invoiceItemModels.Sum(p => p.Subtotal),
//                TaxTotal = invoiceItemModels.Sum(p => p.TaxTotal),
//                Total = invoiceItemModels.Sum(p => p.Total),
//                UpdatedDateUTC = DateTime.UtcNow
//            };

//            var result = _invoiceService.CreateInvoiceAsync(invoiceModel);
//            return Json(result);
//        }

//        // POST api/<controller>/PostSendInvoiceEmail
//        [Route("[action]")]
//        [HttpPost]
//        public async Task<IActionResult> PostSendInvoiceEmail([FromBody]InvoiceEmailRequestModel invoice)
//        {
//            UrlClass url = new UrlClass();
//            string imageURL = url.showURL(_httpContextAccessor).ToString();

//            var result = new ResultModel();
            
//            var invoiceModel = _invoiceService.SearchInvoice(invoice.InvoiceId);

//            invoiceModel.ImageUrl = imageURL;
//            if (invoiceModel != null)
//            {

//                try
//                {
//                    string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/Invoices/Invoice.cshtml", invoiceModel);

//                    await _emailSender.SendEmailAsync(invoiceModel.PatientEmail, "JuniorMath invoice", string.Empty, body);

//                    result.Success = true;
//                    result.Message = "Email has been sent successfully.";
//                }
//                catch (Exception ex)
//                {
//                    result.Message = "Oops, Email was not sent. please try again. ";
//                }
//            }
//            else
//            {
//                result.Message = "Invalid invoice Id, Please choose right one and try again. ";
//            }

//            return Json(result);
//        }

//        // POST api/<controller>/PostApplyPayment
//        [Route("[action]")]
//        [HttpPost]
//        public IActionResult PostApplyPayment([FromBody]InvoicePaymentRequestModel invoicePayment)
//        {
//            var result = new PaymentResultApiModel();

//            try
//            {
//                result = _paymentService.ApplyPayment(invoicePayment);
//                result.Message = result.Approved? "Payment has been processed successfully." :
//                    "Oops, Payment was not processed!!!";
//            }
//            catch (Exception ex)
//            {
//                result.Message = "Oops, Payment cannot be processed. ";
//            }

//            return Json(result);
//        }
//    }
//}
