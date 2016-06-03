using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalUserMapper
    {
        public static DalUser ToDalUser(this User user)
        {
            if (user == null)
                return null;

            return new DalUser
            {
                Email = user.Email,
                Password = user.Password,
                CreationDate = user.CreationDate,
                Id = user.Id,
                Role = new DalRole()
                {
                    Id = user.Role.Id,
                    Description = user.Role.Description,
                    Name = user.Role.Name
                }
            };
        }

        public static User ToOrmUser(this DalUser user)
        {
            if (user == null)
                return null;

            return new User
            {
                Email = user.Email,
                Password = user.Password,
                CreationDate = DateTime.Now, // TODO Find the problem with Mapping Date
                Id = user.Id,
                RoleId = user.Role.Id
            };
        }
    }
}
