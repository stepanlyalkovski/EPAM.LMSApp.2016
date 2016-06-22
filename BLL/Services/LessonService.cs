using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.DTO.Courses;
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
            //_uow.Lessons.Add(lesson.ToDalLesson());
            _uow.Modules.AttachLesson(lesson.ToDalLesson(), lesson.ModuleId);
            for (int i = 1; i < lesson.PageCount + 1; i++)
            {
                var page = new DalLessonPage
                {
                    Title = $"Page {i}"
                };
                //TODO try with no Local
                _uow.Lessons.AttachPage(page, lesson.ToDalLesson());
            }

            _uow.Complete();
        }

        public void RemoveLesson(LessonEntity lesson)
        {
            _uow.Lessons.Remove(lesson.ToDalLesson());
        }

        public void Update(LessonEntity lesson)
        {
            _uow.Lessons.Update(lesson.ToDalLesson());
            _uow.Complete();
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