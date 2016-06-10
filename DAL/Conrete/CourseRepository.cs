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
            return _context.Set<Course>().Include(c => c.Tags)
                                         .FirstOrDefault(c => c.Id == id).ToDalCourse();
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

        public void AddRange(IEnumerable<DalCourse> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(DalCourse entity)
        {
            _context.Set<Course>().Remove(entity.ToOrmCourse());
        }

        public void RemoveRange(IEnumerable<DalCourse> entities)
        {
            throw new NotImplementedException();
        }

        public DalCourse GetByTitle(string title)
        {
            return _context.Set<Course>().Include(c => c.Tags)
                                         .FirstOrDefault(c => c.Title == title).ToDalCourse();
        }

        public void AddModule(int courseId, DalModule module)
        {
            //TODO search for another way
            var ormCourse = _context.Set<Course>().Find(courseId);
            _context.Entry(ormCourse).Collection(c => c.Modules).Load();
            if (ormCourse.Modules == null)
                ormCourse.Modules = new List<Module>();
            ormCourse.Modules.Add(module.ToOrmModule());
            
        }
    }
}