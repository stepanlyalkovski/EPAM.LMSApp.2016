using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.Repository
{
    public interface IUserRepository : IRepository<DalUser>
    {
        void UpdateRole(int id, int roleId);
        DalUser GetUserByEmail(string email);
        DalUser Get(string email);     
    }
}
