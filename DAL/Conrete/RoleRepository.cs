using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using ORM;

namespace DAL.Conrete
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _context;

        public RoleRepository(DbContext context)
        {
            _context = context;
        }
        public DalRole Get(int id)
        {
            var role = _context.Set<Role>().FirstOrDefault(r => r.Id == id);
            return role != null ? new DalRole() {Id = role.Id, Name = role.Name, Description = role.Description} 
                                : null;
        }

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetAll()
        {
            var roles =
                _context.Set<Role>().Select(r => new DalRole {Id = r.Id, Name = r.Name, Description = r.Description})
                                    .ToList();
            return roles;
        }

        public DalRole GetRoleByName(string name)
        {
            var role = _context.Set<Role>().FirstOrDefault(r => r.Name == name);
            return role != null ? new DalRole() { Id = role.Id, Name = role.Name, Description = role.Description }
                               : null;
        }

        #region NotImplemented
        public IEnumerable<DalRole> Find(Expression<Func<DalRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRole(int id, int roleId)
        {
            throw new NotImplementedException();
        }

        
#endregion
    }
}
