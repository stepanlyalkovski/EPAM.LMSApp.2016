using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Helpers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Courses;
using ORM.Courses.Content;

namespace ORM
{
    class DbInitializer : DropCreateDatabaseAlways<EntityModel>
    {
        protected override void Seed(EntityModel db)
        {
            IList<Role> defaultRoles = new List<Role>
            {
                new Role {Name = "Admin"},
                new Role {Name = "Student" },
                new Role {Name = "Manager"}
            };

            db.Roles.AddRange(defaultRoles);
            db.SaveChanges();

            User admin = new User
            {
                Email = "admin@gmail.com",
                Password = Crypto.HashPassword("admin"),
                RoleId = defaultRoles.FirstOrDefault(r => r.Name == "Admin").Id,
                CreationDate = DateTime.Now
            };
            Profile adminProfile = new Profile
            {
                Age = 0,
                LastName = "CallMeAdmin",
                User = admin
            };
            User student = new User
            {
                Email = "student@gmail.com",
                Password = Crypto.HashPassword("student"),
                RoleId = defaultRoles.FirstOrDefault(r => r.Name == "Student").Id,
                CreationDate = DateTime.Now
            };
            Profile studentProfile = new Profile
            {
                Age = 19,
                LastName = "Ivanov",
                FirstName = "Ivan",
                User = student
            };
            User manager = new User
            {
                Email = "manager@gmail.com",
                Password = Crypto.HashPassword("manager"),
                RoleId = defaultRoles.FirstOrDefault(r => r.Name == "Manager").Id,
                CreationDate = DateTime.Now
            };
            Profile managerProfile = new Profile
            {
                Age = 45,
                LastName = "Samal",
                FirstName = "Dmitriy",
                User = manager
            };
            
            db.Users.AddRange(new List<User> {student, manager, admin});
            db.Profiles.AddRange(new List<Profile> {adminProfile, studentProfile, managerProfile});

            //db.SaveChanges();


            var storage = new UserStorage { User = manager, StorageName = "Storage" };

            db.UserStorages.Add(storage);
            db.SaveChanges();

            Course course = new Course
            {
                Description = "Introduction to Platform",
                UserStorage = storage,
                Title = "Welcome to Demo Platform Course!"
            };

            Tag tag = new Tag("Demo");
            Tag tag2 = new Tag("Platform Tutorial");

            Module module = new Module
            {
                Description = "In this module you will see...",
                Title = "What I am doing here?",
                Courses = new List<Course>()
            };
            Module module2 = new Module
            {
                Description = "The second module",
                Title = "Coding",
                Courses = new List<Course>()
            };
            module2.Courses.Add(course);
            module.Courses.Add(course);


            db.Courses.Add(course);
            db.Tags.Add(tag);
            db.Tags.Add(tag2);
            db.Modules.Add(module);
            db.Modules.Add(module2);
            db.SaveChanges();

            course.Tags = new List<Tag> { tag, tag2 };
            Lesson lesson = new Lesson
            {
                Title = "Learn to learn",
                Description = "In this lesson you will learn how to use platform"
            };

            Lesson lessonMod2 = new Lesson
            {
                Title = "lesson in module N 2",
                Description = "In this lesson you will learn how to use Module N 2"
            };

            LessonPage page = new LessonPage
            {
                Text = "I will type something later...",
                Title = "Page 1"
            };
            LessonPage page2 = new LessonPage
            {
                Text = "Another page...",
                Title = "Page 2"
            };

            LessonPage page1Mod2 = new LessonPage
            {
                Text = "Page in module 2",
                Title = "Page 1"
            };

            HtmlArticle article = new HtmlArticle { Title = "Aticle", HtmlData = "<h1>AwesomeTitle!</h1>" };
            db.HtmlArticles.Add(article);
            db.Lessons.Add(lesson);
            db.Lessons.Add(lessonMod2);
            db.LessonPages.Add(page);
            db.LessonPages.Add(page1Mod2);
            db.LessonPages.Add(page2);
            module.HtmlArticles = new List<HtmlArticle> { article };
            module2.HtmlArticles = new List<HtmlArticle> { article };
            module2.Lesson = lessonMod2;
            module.Lesson = lesson;
            db.Entry(module).State = EntityState.Modified;
            lesson.Pages = new List<LessonPage> { page, page2 };
            lessonMod2.Pages = new List<LessonPage> {page1Mod2};
            db.SaveChanges();

            UserStorage userStorage = new UserStorage { User = student, StorageName = "Ivan's Storage" };
            db.UserStorages.Add(userStorage);
            db.SaveChanges();

            Enrolment enr = new Enrolment
            {
                Course = course,
                CourseCompleted = false,
                Profile = student.Profile
            };
            db.Enrolments.Add(enr);
            enr.Progress = new List<CourseProgress>(course.Modules.Count);
            foreach (var mod in course.Modules.Where(mod => mod.Lesson != null))
            {
                enr.Progress.Add(new CourseProgress
                {
                    Enrolment = enr,
                    Module = mod,
                    LessonCompleted = false,
                    QuizCompleted = false
                });
            }
        }
    }
}
