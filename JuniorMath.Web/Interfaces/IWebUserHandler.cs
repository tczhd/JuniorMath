using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.DTOs.User;

namespace JuniorMath.Web.Interfaces
{
    public interface IWebUserHandler
    {
        UserContext GetUserContext();
    }
}
