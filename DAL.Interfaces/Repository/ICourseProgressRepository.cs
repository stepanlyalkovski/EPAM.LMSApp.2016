using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.Repository
{
    public interface ICourseProgressRepository : IRepository<DalCourseProgress>
    {
        IEnumerable<DalCourseProgress> GetEnrolmentProgress(int enrolmentId);
        DalCourseProgress Get(int enrolmentId, int moduleId);
    }
}