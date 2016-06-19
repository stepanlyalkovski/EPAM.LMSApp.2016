using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _uow;

        public CourseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public CourseEntity GetByTitle(string title)
        {
            return _uow.Courses.Get(title).ToBllCourseEntity();
        }

        public CourseEntity Get(int courseId)
        {
            var bllCourse = _uow.Courses.Get(courseId).ToBllCourseEntity();
            bllCourse.Author = GetAuthorName(bllCourse.UserStorageId); // note that UserStorageID = UserID = profileID
            return bllCourse;
        }

        public IEnumerable<CourseEntity> GetaAll()
        {
           var courses = _uow.Courses.GetAll().Select(c => c.ToBllCourseEntity()).ToList();

            foreach (var course in courses)
            {
                course.Author = GetAuthorName(course.UserStorageId);
            }

            return courses;
        }

        public void AddCourse(CourseEntity course)
        {
            var dalCourse = course.ToDalCourse();
            _uow.Courses.Add(dalCourse);
            int modules = course.ModulesNumber;

            for (int i = 0; i < modules; i++)
            {
                var emptyModule = new DalModule {Title = $"Chapter {i}", Description = $"Chapter {i} Description" };
                _uow.Courses.AttachModule(emptyModule, dalCourse);
            }
            _uow.Complete();
        }

        public IEnumerable<CourseEntity> GetCreatedCourses(int storageId)
        {
           return _uow.Courses.GetStorageCourses(storageId).Select(c => c.ToBllCourseEntity());
        }

        private string GetAuthorName(int profileId)
        {
            var authorProfile = _uow.Profiles.Get(profileId);

            if (authorProfile.LastName == null)
                return "Anonymous";

            return authorProfile.FirstName + " " + authorProfile.LastName;
        }
    }
}