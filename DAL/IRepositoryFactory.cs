using System.Data.Entity;
using DAL.Interfaces.Repository;

namespace DAL
{
    public interface IRepositoryFactory
    {
        IUserRepository CreateUserRepository(DbContext context);
        IRoleRepository CreateRoleRepository(DbContext context);
        IProfileRepository CreateProfileRepository(DbContext context);
        IStorageRepository CreateStorageRepository(DbContext context);
        ICourseRepository CreateCourseRepository(DbContext context);
        IModuleRepository CreateModuleRepository(DbContext context);
        ILessonRepository CreateLessonRepository(DbContext context);
        ILessonPageRepository CreateLessonPageRepository(DbContext context);
    }
}
