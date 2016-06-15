using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Services
{
    public interface IStorageService
    {
        void AddCourse(int storageId, CourseEntity course);
        IEnumerable<CourseEntity> GetCreatedCourses(int storageId);
        //void RemoveCourse(int storageId, DalCourse course);
        //void UpdateCourse(int storageId, DalCourse course);
    }
}