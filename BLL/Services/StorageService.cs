using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class StorageService : IStorageService
    {
        private readonly IUnitOfWork _uow;

        public StorageService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void AddCourse(int storageId, CourseEntity course)
        {
            _uow.Storages.AddCourse(storageId, course.ToDalCourse());
            _uow.Complete();
        }

        public IEnumerable<CourseEntity> GetCreatedCourses(int storageId)
        {
            return _uow.Storages.GetCreatedCourses(storageId).Select(c => c.ToBllCourseEntity());
        }
    }
}