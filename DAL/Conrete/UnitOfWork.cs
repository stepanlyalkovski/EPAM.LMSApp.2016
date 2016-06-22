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
        public IProfileRepository Profiles { get; set; }
        public IStorageRepository Storages { get; set; }
        public ICourseRepository Courses { get; set; }
        public IModuleRepository Modules { get; set; }
        public IQuizRepository Quizzes { get; set; }
        public IHtmlArticleRepository Articles { get; set; }
        public ILessonRepository Lessons { get; set; }
        public ILessonPageRepository LessonPages { get; set; }
        public IImageRepository Images { get; set; }
        public ICodeSampleRepository CodeSamples { get; set; }
        public IEnrolmentRepository Enrolments { get; set; }
        public ICourseProgressRepository CourseProgresses { get; set; }
        public ITagRepository Tags { get; set; }

        public UnitOfWork(DbContext context, IRepositoryFactory factory)
        {
            _context = context;
            _repositoryFactory = factory;

            Users = factory.CreateUserRepository(context);
            Roles = factory.CreateRoleRepository(context);
            Profiles = factory.CreateProfileRepository(context);
            Storages = factory.CreateStorageRepository(context);
            Courses = factory.CreateCourseRepository(context);
            Modules = factory.CreateModuleRepository(context);
            Quizzes = factory.CreateQuizRepository(context);
            Articles = factory.CreaHtmlArticleRepository(context);
            Lessons = factory.CreateLessonRepository(context);
            LessonPages = factory.CreateLessonPageRepository(context);
            Images = factory.CreaImageRepository(context);
            CodeSamples = factory.CreateCodeSampleRepository(context);
            Enrolments = factory.CreatEnrolmentRepository(context);
            CourseProgresses = factory.CreateCourseProgressRepository(context);
            Tags = factory.CreaTagRepository(context);
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
