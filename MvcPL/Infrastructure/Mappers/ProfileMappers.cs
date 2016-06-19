using AutoMapper;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Courses;
using MvcPL.Models;
using MvcPL.Models.ProfileModels;

namespace MvcPL.Infrastructure.Mappers
{
    public static class ProfileMappers
    {
        public static ProfileViewModule ToProfileViewModel(this ProfileEntity profile)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProfileEntity, ProfileViewModule>());
            return Mapper.Map<ProfileViewModule>(profile);
        }

        public static ProfileEntity ToProfileViewModel(this ProfileViewModule profile)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProfileViewModule, ProfileEntity>());
            return Mapper.Map<ProfileEntity>(profile);
        }
    }
}