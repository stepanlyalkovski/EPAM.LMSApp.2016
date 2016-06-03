using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repository;

namespace DAL.Conrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IRepositoryFactory _repositoryFactory;
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public UnitOfWork(DbContext context, IRepositoryFactory factory)
        {
            _context = context;
            _repositoryFactory = factory;

            Users = factory.CreateUserRepository(context);
            Roles = factory.CreateRoleRepository(context);

        }
        public void Dispose()
        {
            _context.Dispose();
        }

        
        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
