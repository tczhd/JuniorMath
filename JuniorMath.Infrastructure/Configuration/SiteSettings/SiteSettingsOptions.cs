using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.Infrastructure.Configuration.SiteSettings
{
    public class SiteSettingsOptions
    {
        public  bool Production { get; set; }
        public string AzureSearchServiceName { get; set; }
        public string AzureSearchApiKey { get; set; }
    }
}
