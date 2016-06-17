using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM.Courses;
using ORM.Courses.Content;

namespace DAL.Conrete
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly DbContext _context;
        public ModuleRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(DalModule module)
        {
            if(module != null)
                _context.Set<Module>().Add(module.ToOrmModule());
        }

        public IEnumerable<DalModule> GetCourseModules(int courseId)
        {
            return _context.Set<Course>().Find(courseId).Modules.Select(m => m.ToDalModule());
        }

        public DalModule Get(int courseId, string title)
        {
            return _context.Set<Course>().Find(courseId).Modules.FirstOrDefault(m => m.Title == title).ToDalModule();
        }

        public void AttachLesson(DalLesson lesson, int moduleId)
        {
            var module = _context.Set<Module>().Find(moduleId);
            module.Lesson = lesson.ToOrmLesson();
        }

        public void AttachQuiz(DalQuiz quiz, int moduleId)
        {
            var module = _context.Set<Module>().Find(moduleId);
            module.QuizId = quiz.Id;
        }

        public void AttachArticle(DalHtmlArticle article, int moduleId)
        {
            var module = _context.Set<Module>().Find(moduleId);
            var dbArticle = _context.Set<HtmlArticle>().Find(article.Id);
            if(module.HtmlArticles == null)
                module.HtmlArticles = new List<HtmlArticle>();
            module.HtmlArticles.Add(dbArticle);
        }

        public DalModule Get(int id)
        {
            return _context.Set<Module>().Find(id).ToDalModule();

        }

        public void Update(DalModule entity)
        {
            var module = _context.Set<Module>().Find(entity.Id);
            var newModule = entity.ToOrmModule();
            module.Description = newModule.Description;
            module.Title = newModule.Title;

        }

        public IEnumerable<DalModule> GetAll()
        {
            return _context.Set<Module>().Select(m => m.ToDalModule()).ToList();
        }

        public void Remove(DalModule module)
        {
            var ormModule = _context.Set<Module>().Find(module.Id);
            _context.Set<Module>().Remove(ormModule);
        }       

        //public IEnumerable<DalModule> GetAll()
        //{
        //    return _context.Set<Module>().Include(m => m.HtmlArticles)
        //                                 .Include(m => m.Lesson)
        //                                 .Include(m => m.Quiz).Select(m => m.ToDalModule());
        //}

    }
}