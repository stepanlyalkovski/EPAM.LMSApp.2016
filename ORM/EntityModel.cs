using System.Data.Entity;
using ORM.Courses;
using ORM.Courses.Content;

namespace ORM
{
    public class EntityModel : DbContext 
    {
        static EntityModel()
        {
            Database.SetInitializer(new DbInitializer());
        }

        //TODO string connectionString
        public EntityModel() : base("EntityModel")
        {
            
        }
           
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<HtmlArticle> HtmlArticles { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonPage> LessonPages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<CodeSample> CodeSamples { get; set; }

        public DbSet<UserStorage> UserStorages { get; set; }
    }
}