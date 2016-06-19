using AutoMapper;
using BLL.Interfaces.Entities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    public static class BllStorageMapper
    {
        public static UserStorageEntity ToUserStorageEntity(this DalUserStorage storage)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DalUserStorage, UserStorageEntity>());
            return Mapper.Map<UserStorageEntity>(storage);
        }

        public static DalUserStorage ToDalUserStorageEntity(this UserStorageEntity storage)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserStorageEntity, DalUserStorage>());
            return Mapper.Map<DalUserStorage>(storage);
        }
    }
}