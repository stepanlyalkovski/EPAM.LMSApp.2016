using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IProfileRepository Profiles { get; set; }
        IStorageRepository Storages { get; set; }
        ICourseRepository Courses { get; set; }
        IModuleRepository Modules { get; set; }
        IQuizRepository Quizzes { get; set; }
        IHtmlArticleRepository Articles { get; set; }
        ILessonRepository Lessons { get; set; }
        ILessonPageRepository LessonPages { get; set; }
        int Complete();
    }
}
