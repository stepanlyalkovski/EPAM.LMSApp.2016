using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _uow;

        public LessonService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddLesson(LessonEntity lesson)
        {
            _uow.Lessons.Add(lesson.ToDalLesson());
        }

        public void RemoveLesson(LessonEntity lesson)
        {
            _uow.Lessons.Remove(lesson.ToDalLesson());
        }

        public void Update(LessonEntity lesson)
        {
            _uow.Lessons.Update(lesson.ToDalLesson());
        }

        public LessonEntity GetLesson(int lessonId)
        {
            return _uow.Lessons.Get(lessonId).ToLessonEntity();
        }

        public LessonEntity GetModuleLesson(int moduleId)
        {
            return _uow.Lessons.GetModuleLesson(moduleId).ToLessonEntity();
        }
    }
}