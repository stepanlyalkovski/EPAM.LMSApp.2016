using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;

namespace DAL.Interfaces.Repository
{
    public interface IRoleRepository : IRepository<DalRole>
    {
        void UpdateRole(int id, int roleId);
        DalUser GetUserByName(string name);
    }
}
