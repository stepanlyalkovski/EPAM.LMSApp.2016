using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;
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
            return _context.Set<User>().Include(u => u.Profile)
                                       .Include(u => u.Role)
                                       .Include(u => u.UserStorage)
                                       .FirstOrDefault(u => u.Id == id).ToDalUser();         
        }

        public DalUser Get(string email)
        {
            return _context.Set<User>().Include(u => u.Profile)
                                       .Include(u => u.Role)
                                       .Include(u => u.UserStorage)
                                       .FirstOrDefault(u => u.Email== email).ToDalUser();
        }

        public void Update(DalUser entity)
        {
            var user = _context.Set<User>().Find(entity.Id);
            var newUser = entity.ToOrmUser();
            user.UserStorage = newUser.UserStorage;
            user.Email = newUser.Email;
            user.Password = newUser.Password;
            user.Profile = newUser.Profile;
                                 
            _context.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().Include(u => u.Profile).ToList().Select(u => u.ToDalUser());
        }

        public IEnumerable<DalUser> Find(Expression<Func<DalUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(DalUser entity)
        {

            entity.Profile = new DalProfile {Age = 0, LastName = "Student"};
            _context.Set<User>().Add(entity.ToOrmUser());

        }

        public void Remove(DalUser entity)
        {
            var user = _context.Set<User>().Find(entity.Id);
           
            _context.Set<User>().Remove(user);
        }

        public void UpdateRole(int id, int roleId)
        {
            throw new NotImplementedException();
        }

        public DalUser GetUserByEmail(string email)
        {
            return _context.Set<User>().Include(u => u.Profile)
                                       .FirstOrDefault(u => u.Email == email).ToDalUser();
        }

        public void AttendCourse(DalCourse course)
        {
            throw new NotImplementedException();
        }

    }
}