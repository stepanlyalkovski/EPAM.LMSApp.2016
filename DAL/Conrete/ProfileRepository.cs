using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;
using ORM.Courses;

namespace DAL.Conrete
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DbContext _context;

        public ProfileRepository(DbContext context)
        {
            _context = context;
        }
        public void AddEnrolment(int profileId, int courseId)
        {
            var enrolment = new DalEnrolment { CourseId = courseId, ProfileId = profileId };
            var course = _context.Set<Course>().Find(courseId);

            foreach (var module in course.Modules)
            {
                bool quizCompleted = module.Quiz == null;
                bool lessonCompleted = module.Lesson == null;
                var progress = new CourseProgress
                {
                    Enrolment = enrolment.ToOrmEnrolment(),
                    Module = module,
                    LessonCompleted = lessonCompleted,
                    QuizCompleted = quizCompleted
                };
                _context.Set<CourseProgress>().Add(progress);
            }
        }

        public DalEnrolment GetEnrolment(int profileId, int courseId)
        {
            return _context.Set<Profile>()
                .Find(profileId)
                .Enrolment.FirstOrDefault(e => e.CourseId == courseId).ToDalEnrolment();
        }

        public IEnumerable<DalCourseProgress> GetModulesProgress(int enrolmentId)
        {
            return _context.Set<Enrolment>().Find(enrolmentId).Progress
                                                              .Select(p => p.ToDalCourseProgress());
        }

        public void ChangeQuizProgress(int enrolmentId, int moduleId, bool completeStatus)
        {
            var progress =_context.Set<Enrolment>()
                .Find(enrolmentId)
                .Progress.FirstOrDefault(p => p.ModuleId == moduleId);
            if (progress != null)
                progress.QuizCompleted = completeStatus;

        }

        public void ChangeLessonProgress(int enrolmentId, int moduleId, bool completeStatus)
        {
            var progress = _context.Set<Enrolment>()
                .Find(enrolmentId)
                .Progress.FirstOrDefault(p => p.ModuleId == moduleId);
            if (progress != null)
                progress.QuizCompleted = completeStatus;
        }

        public void ChangeCourseProgress(int profileId, int courseId, bool completeStatus)
        {
            var enrolment = _context.Set<Profile>().Find(profileId)
                                                   .Enrolment.FirstOrDefault(e => e.CourseId == courseId);
            if(enrolment != null)
                enrolment.CourseCompleted = completeStatus;
        }
    }
}