using AutoMapper;
using BLL.Interfaces.Entities.Courses;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;
using ProfileEntity = BLL.Interfaces.Entities.ProfileEntity;

namespace BLL.Mappers
{
    public static class BllProfileMapper
    {
        public static ProfileEntity ToProfileEntity(this DalProfile profile)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalProfile, ProfileEntity>());
            return Mapper.Map<ProfileEntity>(profile);
        }

        public static DalProfile ToDalProfile(this ProfileEntity profile)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProfileEntity, DalProfile>());
            return Mapper.Map<DalProfile>(profile);
        }

    }
}