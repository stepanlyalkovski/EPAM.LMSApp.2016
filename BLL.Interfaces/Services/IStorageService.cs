using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Services
{
    public interface IStorageService
    {
        void AddCourse(int storageId, CourseEntity course);
        IEnumerable<CourseEntity> GetCreatedCourses(int storageId);

    }
}