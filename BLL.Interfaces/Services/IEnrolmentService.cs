using System.Collections.Generic;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Services
{
    public interface IEnrolmentService
    {
        void AttendCourse(int profileId, int courseId);
        EnrolmentEntity GetEnrolment(int profileId, int courseId);
        void Remove(EnrolmentEntity enrolment);
        IEnumerable<CourseProgressEntity> GetModulesProgress(int enrolmentId);
        IEnumerable<EnrolmentEntity> GetStudentEnrolments(int profileId); 

        void ChangeQuizProgress(int enrolmentId, int moduleId, bool completeStatus);
        void ChangeLessonProgress(int enrolmentId, int moduleId, bool completeStatus);
        void ChangeCourseProgress(int profileId, int courseId, bool completeStatus);
        void ChangeCourseProgress(int enrolmentId, bool completeStatus);
    }
}