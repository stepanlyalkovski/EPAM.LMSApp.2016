using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM.Courses;

namespace DAL.Conrete
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DbContext _context;

        public CourseRepository(DbContext context)
        {
            _context = context;
        }

        public DalCourse Get(int id)
        {
            return _context.Set<Course>().Find(id).ToDalCourse();
        }

        public void Update(DalCourse entity)
        {
            // TODO change not very pretty way to update entity
            var course = _context.Set<Course>().Find(entity.Id);
            var newCourse = entity.ToOrmCourse();
            course.Decription = newCourse.Decription;
            course.Title = newCourse.Title;
            course.Published = newCourse.Published;
                                   
        }

        public IEnumerable<DalCourse> GetAll()
        {
            return _context.Set<Course>().Include(c => c.Tags).ToDalCourses();
        }

        public IEnumerable<DalCourse> Find(Expression<Func<DalCourse, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(DalCourse entity)
        {
            _context.Set<Course>().Add(entity.ToOrmCourse());
        }

        public void Remove(DalCourse entity)
        {
            var course = _context.Set<Course>().Find(entity.Id);
            _context.Set<Course>().Remove(course);
        }

        public DalCourse GetByTitle(string title)
        {
            return _context.Set<Course>().FirstOrDefault(c => c.Title == title).ToDalCourse();
        }

        public void AddModule(int courseId, DalModule module)
        {
            //TODO search for another way
            var ormCourse = _context.Set<Course>().Find(courseId);
            var modules = ormCourse.Modules ?? new List<Module>();
            modules.Add(module.ToOrmModule());
            ormCourse.Modules = modules;
        }

        public IEnumerable<DalModule> GetModules(int courseId)
        {
            return _context.Set<Course>().Find(courseId).Modules.Select(m => m.ToDalModule());
        }

        public DalModule GetModule(int courseId, string title)
        {
            return _context.Set<Course>().Find(courseId).Modules.FirstOrDefault(m => m.Title == title).ToDalModule();
        }
    }
}