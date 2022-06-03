using JuniorMath.ApplicationCore.DTOs.Common;
using JuniorMath.ApplicationCore.DTOs.Question;
using JuniorMath.ApplicationCore.Entities;
using JuniorMath.ApplicationCore.Entities.QuestionAggregate;
using JuniorMath.ApplicationCore.Entities.SettingsAggregate;
using JuniorMath.ApplicationCore.Entities.UserAggregate;
using JuniorMath.ApplicationCore.Interfaces.Repository;
using JuniorMath.ApplicationCore.Interfaces.Services.Utiliites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JuniorMath.ApplicationCore.Services.Utiliites
{
    public class UtilityService : IUtilityService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Region> _regionRepository;
        private readonly IRepository<SiteUserLevel> _siteUserLevelRepository;
        private readonly IRepository<QuestionImageSetting> _questionImageSettingRepository;

        public UtilityService(IRepository<Country> countryRepository
            , IRepository<Region> regionRepository
            , IRepository<SiteUserLevel> siteUserLevelRepository
            , IRepository<QuestionImageSetting> questionImageSettingRepository)
        {
            _countryRepository = countryRepository;
            _regionRepository = regionRepository;
            _siteUserLevelRepository = siteUserLevelRepository;
            _questionImageSettingRepository = questionImageSettingRepository;
        }
        public List<ListItemModel> GetCountries()
        {
            var data = _countryRepository.ListAll().Select(p => new ListItemModel {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return data;
        }

        public List<ListItemModel> GetRegions()
        {
            var data = _regionRepository.ListAll().Select(p => new ListItemModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return data;
        }

        public List<ListItemModel> GetSiteUserLevel()
        {
            var data = _siteUserLevelRepository.ListAll().Select(p => new ListItemModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return data;
        }

        public List<QuestionImageSettingModel> GetQuestionImageSettingModels()
        {
            var data = _questionImageSettingRepository.ListAll().Select(p => (QuestionImageSettingModel)p).ToList();

            return data;
        }
    }
}
