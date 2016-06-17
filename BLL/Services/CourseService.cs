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
            return _uow.Courses.Get(courseId).ToBllCourseEntity();
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
    }
}