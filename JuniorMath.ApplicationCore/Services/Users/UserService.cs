using JuniorMath.ApplicationCore.Domain.User;
using JuniorMath.ApplicationCore.DTOs.Common;
using JuniorMath.ApplicationCore.DTOs.User;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using JuniorMath.ApplicationCore.Enums;
using JuniorMath.ApplicationCore.Interfaces.Repository;
using JuniorMath.ApplicationCore.Interfaces.Services.Users;
using JuniorMath.ApplicationCore.Specifications.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JuniorMath.ApplicationCore.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<SiteUser> _siteUserRepository;
        private readonly UserHandler _userHandler;

        public UserService(IRepository<SiteUser> siteUserRepository,  UserHandler userHandler)
        {
            _siteUserRepository = siteUserRepository;
            _userHandler = userHandler;
        }

        public UserContext GetUserContextAsync(string userId)
        {
            try
            {
                var userContextSpefification = new UserContextSpefification();
                userContextSpefification.AddUserId(userId);

                var siteUser = _siteUserRepository.GetSingleBySpec(userContextSpefification);

                var result = new UserContext
                {
                    SiteUserId = siteUser.Id,
                    SiteUserName = $"{siteUser.FirstName} {siteUser.LastName}",
                    SiteUserLevelId = siteUser.SiteUserLevelId,
                    SiteUserLevelName = siteUser.SiteUserLevel.Name
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot find the site user. ");
            }
        }

        public Result RegisterUser(SiteUserModel siteUserModel)
        {
            var userContext = _userHandler.GetUserContext();
            var result = new Result();
            if (userContext == null)
            {
                result.Message = "Session expired. ";
                return result;
            }

            try
            {
                var siteUser = new SiteUser() {
                    FirstName = siteUserModel.FirstName,
                    LastName = siteUserModel.LastName,
                    Email = siteUserModel.Email,
                    UserId = siteUserModel.UserId,
                    SiteUserLevelId = siteUserModel.SiteUserLevelId,
                    Active= true,
                };

                _siteUserRepository.Add(siteUser);

                result.Success = true;
                result.Message = "Create user success. ";
            }
            catch (Exception ex)
            {
                result.Message = "Add user failed: " + ex.Message;
            }

            return result;
        }

        public List<SiteUserModel> SearchSiteUsers()
        {
            var userContext = _userHandler.GetUserContext();
            var userLevelTypes = new List<SiteUserLevelType>();

            switch ((SiteUserLevelType)userContext.SiteUserLevelId)
            {
                case SiteUserLevelType.Student:
                    userLevelTypes.Add(SiteUserLevelType.Student);
                    break;
                case SiteUserLevelType.Teacher:
                    userLevelTypes.Add(SiteUserLevelType.Teacher);
                    userLevelTypes.Add(SiteUserLevelType.Student);
                    break;
                 default:
                    userLevelTypes.Add(SiteUserLevelType.Teacher);
                    userLevelTypes.Add(SiteUserLevelType.Student);
                    userLevelTypes.Add(SiteUserLevelType.AdminUser);
                    break;
            }

            var searchSiteUserSpecification = new SearchSiteUserSpecification();
            searchSiteUserSpecification.AddSiteUserLevels(userLevelTypes);

            var users = _siteUserRepository.List(searchSiteUserSpecification).ToList();

            var result = users.Select(p => new SiteUserModel {
                Email = p.Email,
                FirstName = p.FirstName,
                LastName = p.LastName,
                SiteUserLevelId = p.SiteUserLevelId,
                SiteUserLevelName = p.SiteUserLevel.Name
            }).ToList();

            return result;
        }
    }
}
