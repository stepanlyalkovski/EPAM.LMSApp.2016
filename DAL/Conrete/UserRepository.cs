using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Conrete
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public DalUser Get(int id)
        {
            return _context.Set<User>().FirstOrDefault(u => u.Id == id).ToDalUser();
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().ToList().Select(u => u.ToDalUser());
        }

        public IEnumerable<DalUser> Find(Expression<Func<DalUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(DalUser entity)
        {
            
            _context.Set<User>().Add(entity.ToOrmUser());
        }

        public void AddRange(IEnumerable<DalUser> entities)
        {
            _context.Set<User>().AddRange(entities.Select(e => e.ToOrmUser()));
        }

        public void Remove(DalUser entity)
        {
            _context.Set<User>().Remove(entity.ToOrmUser());
        }

        public void RemoveRange(IEnumerable<DalUser> entities)
        {
            _context.Set<User>().RemoveRange(entities.Select(e => e.ToOrmUser()));
        }

        public void UpdateRole(int id, int roleId)
        {
            throw new NotImplementedException();
        }

        public DalUser GetUserByEmail(string email)
        {
            return _context.Set<User>().FirstOrDefault(u => u.Email == email).ToDalUser();
        }
    }
}