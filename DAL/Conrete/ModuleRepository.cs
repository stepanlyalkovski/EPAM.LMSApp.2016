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
            return _context.Set<Module>().Include(m => m.HtmlArticles)
                                         .Include(m => m.Lesson)
                                         .Include(m => m.Quiz).Select(m => m.ToDalModule());
        }

        public IEnumerable<DalModule> Find(Expression<Func<DalModule, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(DalModule entity)
        {
            _context.Set<Module>().Add(entity.ToOrmModule());
        }

        public void Remove(DalModule entity)
        {
            var module = _context.Set<Module>().Find(entity.Id);
            _context.Set<Module>().Remove(module);
        }

        public void AddQuiz(int moduleId, DalQuiz quiz)
        {
            var ormModule = _context.Set<Module>().Find(moduleId);
            if (ormModule.Quiz != null)
                throw new OperationCanceledException("Quiz is already exist");
            ormModule.Quiz = quiz.ToOrmQuiz();
        }

        public void AddArticle(int moduleId, DalHtmlArticle article)
        {
            var ormModule = _context.Set<Module>().Find(moduleId);
            var articles = ormModule.HtmlArticles ?? new List<HtmlArticle>();
            articles.Add(article.ToOrmHtmlArticle());
            ormModule.HtmlArticles = articles;
        }

        public void AddLesson(int moduleId, DalLesson lesson)
        {
           var ormModule = _context.Set<Module>().Find(moduleId);
            if (ormModule.Lesson != null)
                throw new OperationCanceledException("Lesson is already exist");
            ormModule.Lesson = lesson.ToOrmLesson();
        }
    }
}