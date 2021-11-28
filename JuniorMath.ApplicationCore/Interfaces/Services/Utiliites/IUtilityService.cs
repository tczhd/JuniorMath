using JuniorMath.ApplicationCore.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Interfaces.Services.Utiliites
{
    public interface IUtilityService
    {
        List<ListItemModel> GetCountries();
        List<ListItemModel> GetRegions();
        List<ListItemModel> GetServiceGroups();
        List<ListItemModel> GetSiteUserLevel();
    }
}
