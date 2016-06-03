using System.Data.Entity;
using DAL.Interfaces.Repository;

namespace DAL
{
    public interface IRepositoryFactory
    {
        IUserRepository CreateUserRepository(DbContext context);
        IRoleRepository CreateRoleRepository(DbContext context);
    }
}
