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

        public void Add(int courseId, DalModule module)
        {
            //TODO search for another way
            var ormCourse = _context.Set<Course>().Find(courseId);
            var modules = ormCourse.Modules ?? new List<Module>();
            modules.Add(module.ToOrmModule());
            ormCourse.Modules = modules;
        }

        public IEnumerable<DalModule> GetCourseModules(int courseId)
        {
            return _context.Set<Course>().Find(courseId).Modules.Select(m => m.ToDalModule());
        }

        public DalModule Get(int courseId, string title)
        {
            return _context.Set<Course>().Find(courseId).Modules.FirstOrDefault(m => m.Title == title).ToDalModule();
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

        public void Remove(int moduleId)
        {
            var module = _context.Set<Module>().Find(moduleId);
            _context.Set<Module>().Remove(module);
        }       

        //public IEnumerable<DalModule> GetAll()
        //{
        //    return _context.Set<Module>().Include(m => m.HtmlArticles)
        //                                 .Include(m => m.Lesson)
        //                                 .Include(m => m.Quiz).Select(m => m.ToDalModule());
        //}

    }
}