using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Interfaces.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalUserMapper
    {
        static DalUserMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, DalUser>();
                cfg.CreateMap<DalUser, User>();

                cfg.CreateMap<Role, DalRole>();
                cfg.CreateMap<DalRole, Role>();
            });
        }

        public static DalUser ToDalUser(this User user)
        {
            return DalMapper.Mapper.Map<DalUser>(user);
        }

        public static User ToOrmUser(this DalUser user)
        {
            return DalMapper.Mapper.Map<User>(user);

        }
    }
}
