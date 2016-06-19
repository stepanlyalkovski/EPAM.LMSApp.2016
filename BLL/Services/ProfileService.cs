using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _uow;

        public ProfileService(IUnitOfWork uiOfWork)
        {
            _uow = uiOfWork;
        }

        public void Update(ProfileEntity profile)
        {
            _uow.Profiles.Update(profile.ToDalProfile());
            _uow.Complete();
        }

        public ProfileEntity Get(int userId)
        {
            return _uow.Profiles.Get(userId).ToProfileEntity();
        }
    }
}