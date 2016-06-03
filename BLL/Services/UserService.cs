using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public UserEntity GetUserEntity(int id)
        {
            return _unitOfWork.Users.Get(id).ToBllUser();
        }

        public UserEntity GetUserEntity(string email)
        {
            return _unitOfWork.Users.GetUserByEmail(email).ToBllUser();
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return _unitOfWork.Users.GetAll().Select(u => u.ToBllUser());
        }

        public void CreateUser(UserEntity user)
        {
            _unitOfWork.Users.Add(user.ToDalUser());
            _unitOfWork.Complete();
        }

        public void DeleteUser(UserEntity user)
        {
            _unitOfWork.Users.Remove(user.ToDalUser());
            _unitOfWork.Complete();
        }
    }
}
