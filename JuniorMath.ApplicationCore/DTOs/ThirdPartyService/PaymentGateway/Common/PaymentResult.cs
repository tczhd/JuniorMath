using JuniorMath.ApplicationCore.DTOs.Common;
using JuniorMath.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.ThirdPartyService.PaymentGateway.Common
{
    public class PaymentResult : Result
    {
        public PaymentGateWayType PaymentGateWay { get; set; }
    }
}
