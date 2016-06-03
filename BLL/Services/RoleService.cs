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
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RoleEntity GetRoleEntity(int id)
        {
            return _unitOfWork.Roles.Get(id).ToRoleEntity();
        }

        public RoleEntity GetRoleEntity(string name)
        {
            return _unitOfWork.Roles.GetRoleByName(name).ToRoleEntity();
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return _unitOfWork.Roles.GetAll().Select(r => r.ToRoleEntity());
        }
    }
}
