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
            var module = _context.Set<Module>().Include(m => m.Lesson)
                                               .Include(m => m.Quiz)
                                               .Include(m => m.HtmlArticles)
                                               .FirstOrDefault(m => m.Id == id);
            if(module == null)
                throw new NullReferenceException("Module is not exist");

            return module.ToDalModule();
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

        public void AddRange(IEnumerable<DalModule> entities)
        {
            _context.Set<Module>().AddRange(entities.Select(e => e.ToOrmModule()));
        }

        public void Remove(DalModule entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<DalModule> entities)
        {
            throw new NotImplementedException();
        }

        public void AddQuiz(int moduleId, DalQuiz quiz)
        {
            throw new NotImplementedException();
        }

        public void AddArticle(int moduleId, DalHtmlArticle article)
        {
            var ormModule = _context.Set<Module>().Find(moduleId);
            if(ormModule.HtmlArticles == null)
                ormModule.HtmlArticles = new List<HtmlArticle>();
            ormModule.HtmlArticles.Add(article.ToOrmHtmlArticle());
        }

        public void AddLesson(int moduleId, DalLesson lesson)
        {
           var ormModule = _context.Set<Module>().Find(moduleId);
            ormModule.Lesson = lesson.ToOrmLesson();
        }
    }
}