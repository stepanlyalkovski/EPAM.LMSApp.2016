﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(int id);
        UserEntity GetUserEntity(string email);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
    }
}
