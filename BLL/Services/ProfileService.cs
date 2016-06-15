using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _uow;

        public ProfileService(IUnitOfWork uiOfWork)
        {
            _uow = uiOfWork;
        }
        public void AttendCourse(ProfileEntity profile, int courseId)
        {
            
            _uow.Profiles.AddEnrolment(profile.ProfileId, courseId);
            _uow.Complete();
        }

        public EnrolmentEntity GetEnrolment(int profileId, int courseId)
        {
            return _uow.Profiles.GetEnrolment(profileId, courseId).ToEnrolmentEntity();         
        }

        public IEnumerable<CourseProgressEntity> GetModulesProgress(int enrolmentId)
        {
            return _uow.Profiles.GetModulesProgress(enrolmentId).Select(p => p.ToCourseProgressEntity()).ToList();
        }

        public void ChangeQuizProgress(int enrolmentId, int moduleId, bool completeStatus)
        {
            _uow.Profiles.ChangeQuizProgress(enrolmentId, moduleId, completeStatus);
            _uow.Complete();
        }

        public void ChangeLessonProgress(int enrolmentId, int moduleId, bool completeStatus)
        {
            _uow.Profiles.ChangeLessonProgress(enrolmentId, moduleId, completeStatus);
            _uow.Complete();
        }

        public void ChangeCourseProgress(int profileId, int courseId, bool completeStatus)
        {
            _uow.Profiles.ChangeCourseProgress(profileId, courseId, completeStatus);
        }
    }
}