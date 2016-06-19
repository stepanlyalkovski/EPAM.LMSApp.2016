using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Entities.Courses.Content;

namespace BLL.Interfaces.Services
{
    public interface IModuleService
    {
        void AddModule(ModuleEntity module, int courseId);
        void Remove(ModuleEntity module);
        ModuleEntity Get(int moduleId);
        IEnumerable<ModuleEntity> GetCourseModules(int courseId); 
        void Update(ModuleEntity module);

        void AttachLesson(LessonEntity lesson, int moduleId);
        void AttachQuiz(QuizEntity quiz, int moduleId);
        void AttachArticle(HtmlArticleEntity article, int moduleId);

        LessonEntity GetModuleLesson(int moduleId);
        QuizEntity GetModuleQuiz(int moduleId);
        IEnumerable<HtmlArticleEntity> GetModuleArticles(int moduleId);
    }
}