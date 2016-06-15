using System.Collections.Generic;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.Repository
{
    public interface IProfileRepository
    {
        void AddEnrolment(int profileId, int courseId);
        DalEnrolment GetEnrolment(int profileId, int courseId);
        IEnumerable<DalCourseProgress> GetModulesProgress(int enrolmentId);
        void ChangeQuizProgress(int enrolmentId, int moduleId, bool completeStatus);
        void ChangeLessonProgress(int enrolmentId, int moduleId, bool completeStatus);
        void ChangeCourseProgress(int profileId, int courseId, bool completeStatus);
    }
}