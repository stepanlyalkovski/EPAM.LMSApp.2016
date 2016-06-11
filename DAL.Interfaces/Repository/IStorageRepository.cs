using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.Repository
{
    public interface IStorageRepository
    {
        void AddCourse(int storageId, DalCourse course);
        void GetCreatedCourse(int storageId, DalCourse course);
        void RemoveCourse(int storageId, DalCourse course);
        void UpdateCourse(int storageId, DalCourse course);
    }
}