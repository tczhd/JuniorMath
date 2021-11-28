using JuniorMath.ApplicationCore.DTOs.Common;
using JuniorMath.ApplicationCore.Entities;
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
        private readonly IRepository<ServiceGroup> _serviceGroupRepository;
        private readonly IRepository<IndustryCode> _inventoryCodeRepository;
        private readonly IRepository<SiteUserLevel> _siteUserLevelRepository;
        public UtilityService(IRepository<Country> countryRepository
            , IRepository<Region> regionRepository
            , IRepository<ServiceGroup> serviceGroupRepository
            , IRepository<IndustryCode> inventoryCodeRepository
            , IRepository<SiteUserLevel> siteUserLevelRepository)
        {
            _countryRepository = countryRepository;
            _regionRepository = regionRepository;
            _serviceGroupRepository = serviceGroupRepository;
            _inventoryCodeRepository = inventoryCodeRepository;
            _siteUserLevelRepository = siteUserLevelRepository;
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

        public List<ListItemModel> GetServiceGroups()
        {
            var data = _serviceGroupRepository.ListAll().Select(p => new ListItemModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return data;
        }

        public List<ListItemModel> GetIndustryCodes()
        {
            var data = _inventoryCodeRepository.ListAll().Select(p => new ListItemModel
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
    }
}
