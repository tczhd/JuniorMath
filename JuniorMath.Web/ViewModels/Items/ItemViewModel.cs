//using JuniorMath.ApplicationCore.DTOs.Items;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace JuniorMath.Web.ViewModels.Items
//{
//    public class ItemViewModel
//    {
//        [Display(Name = "Item Number")]
//        public int? ItemId { get; set; }
//        [Display(Name = "Item Name")]
//        [StringLength(40, ErrorMessage = "Service must not exceed to 40 characters.", MinimumLength = 1)]
//        public string ItemName { get; set; }
//        [Display(Name = "Description")]
//        public string Description { get; set; }
//        [Display(Name = "Cost")]
//        public decimal Cost { get; set; }
//        [Display(Name = "ServiceGroupId")]
//        public int? ServiceGroupId { get; set; }
//        [Display(Name = "ShortCode")]
//        public string ShortCode { get; set; }
//        [Display(Name = "IndustryCodeId")]
//        public int? IndustryCodeId { get; set; }
//        [Display(Name = "Subscription")]
//        public bool Subscription { get; set; }
//        [Display(Name = "Subscription")]
//        public string SubscriptionDisplay { get; set; }
//        public static implicit operator ItemModel(ItemViewModel source)
//        {
//            return new ItemModel
//            {
//                Cost = source.Cost,
//                Description = source.Description,
//                IndustryCodeId = source.IndustryCodeId,
//                ItemId = source.ItemId??0,
//                ItemName = source.ItemName,
//                ServiceGroupId = source.ServiceGroupId,
//                ShortCode = source.ShortCode,
//                Subscription = source.Subscription
//            };
//        }
//    }
//}
