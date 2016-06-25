using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Entities.Courses.Content;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _uow;

        public ModuleService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void AddModule(ModuleEntity module, int courseId)
        {
            var course = _uow.Courses.Get(courseId);
            _uow.Courses.AttachModule(module.ToDalModule(), course);
            _uow.Complete();

        }

        public void Remove(ModuleEntity module)
        {
            _uow.Modules.Remove(module.ToDalModule());
            _uow.Complete();
        }

        public ModuleEntity Get(int moduleId)
        {
            return _uow.Modules.Get(moduleId).ToModuleEntity();
        }

        public IEnumerable<ModuleEntity> GetCourseModules(int courseId)
        {
            return _uow.Modules.GetCourseModules(courseId).Select(c =>
            {
                var course = c.ToModuleEntity();
                course.CourseId = courseId;
                return course;
            }).ToList();
        }

        public void Update(ModuleEntity module)
        {
            _uow.Modules.Update(module.ToDalModule());
            _uow.Complete();
        }

        public void AttachLesson(LessonEntity lesson, int moduleId)
        {
            _uow.Modules.AttachLesson(lesson.ToDalLesson(), moduleId);
            _uow.Complete();
        }

        public void AttachQuiz(QuizEntity quiz, int moduleId)
        {
            _uow.Modules.AttachQuiz(quiz.ToDalQuiz(), moduleId);
            _uow.Complete();
        }

        public void AttachArticle(HtmlArticleEntity article, int moduleId)
        {
           _uow.Modules.AttachArticle(article.ToDalHtmlArticle(), moduleId);
            _uow.Complete();
        }

        public void DetachArticle(HtmlArticleEntity article, int moduleId)
        {
            _uow.Modules.DetachArticle(article.ToDalHtmlArticle(), moduleId);
            _uow.Complete();
        }

        public LessonEntity GetModuleLesson(int moduleId)
        {
            return _uow.Lessons.GetModuleLesson(moduleId).ToLessonEntity();
        }

        public QuizEntity GetModuleQuiz(int moduleId)
        {
            return _uow.Quizzes.GetModuleQuiz(moduleId).ToQuizEntity();
        }

        public IEnumerable<HtmlArticleEntity> GetModuleArticles(int moduleId)
        {
            return _uow.Articles.GetModuleArticles(moduleId).Select(a => a.ToHtmlArticleEntity()).ToList();
        }
    }
}