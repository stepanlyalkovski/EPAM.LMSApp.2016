using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Services
{
    public interface IProfileService
    {
        void AttendCourse(ProfileEntity profile, int courseId);
        EnrolmentEntity GetEnrolment(int profileId, int courseId);
        IEnumerable<CourseProgressEntity> GetModulesProgress(int enrolmentId);
        void ChangeQuizProgress(int enrolmentId, int moduleId, bool completeStatus);
        void ChangeLessonProgress(int enrolmentId, int moduleId, bool completeStatus);
        void ChangeCourseProgress(int profileId, int courseId, bool completeStatus);
    }
}