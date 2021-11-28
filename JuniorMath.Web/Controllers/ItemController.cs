//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using JuniorMath.ApplicationCore.DTOs.Common;
//using JuniorMath.ApplicationCore.DTOs.Items;
//using JuniorMath.ApplicationCore.Interfaces.Services.Items;
//using JuniorMath.ApplicationCore.Interfaces.Services.Utiliites;
//using JuniorMath.Web.ViewModels.Base;
//using JuniorMath.Web.ViewModels.Items;


//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace JuniorMath.Web.Controllers
//{
//    [Authorize]
//    [Route("Item")]
//    public class ItemController : Controller
//    {
//        private readonly IItemService _itemService;
//        private readonly IUtilityService _utilityService;

//        public ItemController(IUtilityService utilityService,IItemService itemService)
//        {
//            _utilityService = utilityService;
//            _itemService = itemService;
//        }


//        // GET: /<controller>/
//        [Route("{view=Index}")]
//        public IActionResult Index(int id, string view)
//        {
//            if (view == "ItemForm")
//            {
//                var serviceGroups = _utilityService.GetServiceGroups();

//                ViewBag.ServiceGroups = serviceGroups.Select(p => new ListItemModel
//                {
//                    Id = p.Id,
//                    Name = p.Name
//                }).ToList();

//                if (id == 0)
//                {
//                    ViewData["Title"] = $"New Item";
//                    ViewData["FormType"] = $"New Item";
//                    ViewBag.buttonNname = "Create Service";
//                }
//                else
//                {
//                    ViewData["Title"] = $"Edit Item";
//                    ViewData["FormType"] = $"Edit Item";
//                    ViewBag.buttonNname = "Update Service";

//                    var data = _itemService.SearchItem(id);
//                    if (data != null)
//                    {
//                        var viewData = new ItemViewModel
//                        {
//                            Cost = data.Cost,
//                            Description = data.Description,
//                            ItemId = data.ItemId,
//                            ItemName = data.ItemName,
//                            IndustryCodeId = data.IndustryCodeId,
//                            ServiceGroupId = data.ServiceGroupId,
//                            ShortCode = data.ShortCode,
//                            Subscription = data.Subscription,
//                            SubscriptionDisplay = data.Subscription ? "YES" : "NO"
//                        };

//                        return View(view, viewData);
//                    }
//                    else {
//                        return View(view);
//                    }
//                }
//            }
//            else if (view == "Index")
//            {
//                ViewData["Title"] = $"Search Item";

//                var data = _itemService.SearchItems();
//                var viewData = data.Select(p => new ItemViewModel
//                {
//                    Cost = p.Cost,
//                    Description = p.Description,
//                    ItemId = p.ItemId,
//                    ItemName = p.ItemName,
//                    IndustryCodeId = p.IndustryCodeId,
//                    ServiceGroupId = p.ServiceGroupId,
//                    ShortCode = p.ShortCode,
//                    Subscription = p.Subscription,
//                    SubscriptionDisplay = p.Subscription?"YES":"NO"

//                });
//                return View(view, viewData);
//            }

//            return View(view);
//        }

//        [HttpPost]
//        public IActionResult AddItem(ItemViewModel itemViewModel)
//        {
//            var result = new BaseResultViewModel();

//            if (ModelState.IsValid)
//            {
//                var model = new ItemModel
//                {
//                    ItemId = itemViewModel.ItemId??0,
//                    Cost = itemViewModel.Cost,
//                    Description = itemViewModel.Description,
//                    ItemName = itemViewModel.ItemName,
//                    IndustryCodeId = itemViewModel.IndustryCodeId,
//                    ServiceGroupId = itemViewModel.ServiceGroupId,
//                    ShortCode = itemViewModel.ShortCode,
//                    Subscription = itemViewModel.Subscription
//                };

//                var itemResult = _itemService.SaveItem(model);
//                result.Success = itemResult.Success;
//                result.Message = itemResult.Message;
//            }
//            else {
//                result.Message = "Service name must not exceed to 40 characters.";
//            }
    
//            return View("_SharedResult", result);
//        }

//    }
//}
