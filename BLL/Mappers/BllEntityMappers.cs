using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces.Entities;
using DAL.Interfaces.DTO;

namespace BLL.Mappers
{
    public static class BllEntityMappers
    {
        private static readonly IMapper mapper;

        static BllEntityMappers()
        {
            // TODO DateMapping
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, DalUser>();
                cfg.CreateMap<DalUser, UserEntity>();
                //.ForMember("Role", opt => opt.MapFrom(c => new RoleEntity
                // {
                //     Id = c.Role.Id,
                //     Description = c.Role.Description,
                //     Name = c.Role.Name
                // })
                cfg.CreateMap<RoleEntity, DalRole>();
                cfg.CreateMap<DalRole, RoleEntity>();
            });

            mapper = config.CreateMapper();
        }

        public static DalUser ToDalUser(this UserEntity entity)
        {
            //TODO check null
            return mapper.Map<UserEntity, DalUser>(entity);
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return mapper.Map<DalUser, UserEntity>(dalUser);
        }

        public static DalRole ToDalRole(this RoleEntity entity)
        {
            return mapper.Map<RoleEntity, DalRole>(entity);
        }

        public static RoleEntity ToRoleEntity(this DalRole dalRole)
        {
            return mapper.Map<DalRole, RoleEntity>(dalRole);
        }
    }
}
