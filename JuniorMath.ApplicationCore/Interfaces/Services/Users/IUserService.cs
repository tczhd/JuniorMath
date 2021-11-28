using JuniorMath.ApplicationCore.DTOs.Common;
using JuniorMath.ApplicationCore.DTOs.User;
using System.Collections.Generic;

namespace JuniorMath.ApplicationCore.Interfaces.Services.Users
{
    public interface IUserService
    {
        UserContext GetUserContextAsync(string userId);

        Result RegisterUser(SiteUserModel siteUserModel);

        List<SiteUserModel> SearchSiteUsers();
    }
}
