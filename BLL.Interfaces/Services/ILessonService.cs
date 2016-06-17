using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Services
{
    public interface ILessonService
    {
        void AddLesson(LessonEntity lesson);
        void RemoveLesson(LessonEntity lesson);
        void Update(LessonEntity lesson);
        LessonEntity GetLesson(int lessonId);
        LessonEntity GetModuleLesson(int moduleId);     
    }
}