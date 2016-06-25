using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class EnrolmentService : IEnrolmentService
    {
        private readonly IUnitOfWork _uow;

        public EnrolmentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AttendCourse(int profileId, int courseId)
        {
            var dalEnrolment = new DalEnrolment
            {
                CourseId = courseId,
                ProfileId = profileId,
                CourseCompleted = false
            };
            _uow.Enrolments.Add(dalEnrolment);
            _uow.Enrolments.AttachProgress(dalEnrolment);
            _uow.Complete();
        }

        public EnrolmentEntity GetEnrolment(int profileId, int courseId)
        {
            return _uow.Enrolments.Get(profileId, courseId).ToEnrolmentEntity();
        }

        public void Remove(EnrolmentEntity enrolment)
        {
            _uow.Enrolments.Remove(enrolment.ToDalEnrolment());
            _uow.Complete();
        }

        public IEnumerable<CourseProgressEntity> GetModulesProgress(int enrolmentId)
        {
            return _uow.CourseProgresses.GetEnrolmentProgress(enrolmentId)
                                        .Select(p => p.ToCourseProgressEntity()).ToList();
        }

        public IEnumerable<EnrolmentEntity> GetStudentEnrolments(int profileId)
        {
            return _uow.Enrolments.GetStudentEnrolments(profileId).Select(e => e.ToEnrolmentEntity()).ToList();
        }

        public void ChangeQuizProgress(int enrolmentId, int moduleId, bool completeStatus)
        {
           var progress =  _uow.CourseProgresses.Get(enrolmentId, moduleId);
            progress.QuizCompleted = completeStatus;
            _uow.CourseProgresses.Update(progress);
            _uow.Complete();
        }

        public void ChangeLessonProgress(int enrolmentId, int moduleId, bool completeStatus)
        {
            var progress = _uow.CourseProgresses.Get(enrolmentId, moduleId);
            progress.LessonCompleted = completeStatus;
            _uow.CourseProgresses.Update(progress);
            _uow.Complete();
        }

        public void ChangeCourseProgress(int profileId, int courseId, bool completeStatus)
        {
            var enrolment = _uow.Enrolments.Get(profileId, courseId);
            enrolment.CourseCompleted = completeStatus;
            _uow.Complete();
        }

        public void ChangeCourseProgress(int enrolmentId, bool completeStatus)
        {
            var enrolment = _uow.Enrolments.Get(enrolmentId);
            enrolment.CourseCompleted = completeStatus;
            _uow.Complete();
        }
    }
}