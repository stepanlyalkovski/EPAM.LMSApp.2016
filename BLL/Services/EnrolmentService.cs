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

            SetCourseProgress(profileId, courseId);
        }

        private void SetCourseProgress(int profileId, int courseId)
        {
            var enrolment = _uow.Enrolments.Get(profileId, courseId);
            var modules = _uow.Modules.GetCourseModules(courseId);
            foreach (var module in modules)
            {
                var lesson = _uow.Lessons.GetModuleLesson(module.Id);          
                if(lesson == null)
                    ChangeLessonProgress(enrolment.Id, module.Id, true);

                var quiz = _uow.Quizzes.GetModuleQuiz(module.Id);
                if (quiz == null)
                    ChangeQuizProgress(enrolment.Id, module.Id, true);
            }         
        }

        private void UpdateCourseProgress(int enrolmentId)
        {
            var modulesProgress = GetModulesProgress(enrolmentId);

            if (modulesProgress.All(p => p.QuizCompleted && p.LessonCompleted))
            {
                ChangeCourseProgress(enrolmentId, true);
            }
            
        }

        public EnrolmentEntity GetEnrolment(int profileId, int courseId)
        {
            return _uow.Enrolments.Get(profileId, courseId).ToEnrolmentEntity();
        }

        public EnrolmentEntity GetEnrolment(int enrolmentId)
        {
            return _uow.Enrolments.Get(enrolmentId).ToEnrolmentEntity();
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

        public CourseProgressEntity GetModuleProgress(int enrolmentId, int moduleId)
        {
            return _uow.CourseProgresses.Get(enrolmentId, moduleId).ToCourseProgressEntity();
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

            UpdateCourseProgress(enrolmentId);
        }

        public void ChangeLessonProgress(int enrolmentId, int moduleId, bool completeStatus)
        {
            var progress = _uow.CourseProgresses.Get(enrolmentId, moduleId);
            progress.LessonCompleted = completeStatus;
            _uow.CourseProgresses.Update(progress);
            _uow.Complete();

            UpdateCourseProgress(enrolmentId);
        }

        private void ChangeCourseProgress(int profileId, int courseId, bool completeStatus)
        {
            var enrolment = _uow.Enrolments.Get(profileId, courseId);
            enrolment.CourseCompleted = completeStatus;
            _uow.Complete();
        }

        private void ChangeCourseProgress(int enrolmentId, bool completeStatus)
        {
            var enrolment = _uow.Enrolments.Get(enrolmentId);
            enrolment.CourseCompleted = completeStatus;
            _uow.Enrolments.Update(enrolment);
            _uow.Complete();
        }
    }
}