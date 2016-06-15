using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.Repository
{
    public interface IStorageRepository
    {
        void AddCourse(int storageId, DalCourse course);
        IEnumerable<DalCourse> GetCreatedCourses(int storageId);
        void RemoveCourse(int storageId, DalCourse course);
        void UpdateCourse(int storageId, DalCourse course);
    }
}