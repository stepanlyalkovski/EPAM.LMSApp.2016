using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;
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

        public void Add(DalCourse course)
        {
            Course ormCourse = course.ToOrmCourse();
            ormCourse.Tags = DistinctTags(ormCourse.Tags);
            _context.Set<Course>().Add(ormCourse);
            _context.Entry(ormCourse).State = EntityState.Added;
        }

        public DalCourse Get(int id)
        {
            return _context.Set<Course>().Find(id).ToDalCourse();
        }

        public DalCourse Get(string title)
        {
            return _context.Set<Course>().FirstOrDefault(c => c.Title == title).ToDalCourse();
        }

        public IEnumerable<DalCourse> GetStorageCourses(int storageId)
        {
            return _context.Set<UserStorage>().Find(storageId).Courses.ToDalCourses();
        }

        public void AttachModule(DalModule module, DalCourse course)
        {
            var ormCourse = _context.Set<Course>().Local.First(c => c.Title == course.Title);

                                //try this one

            //var tCourse = _context.Entry(course.ToOrmCourse()).Entity;
            
            if(ormCourse.Modules == null)
                ormCourse.Modules = new List<Module>();

            ormCourse.Modules.Add(module.ToOrmModule());
        }

        public void Remove(DalCourse course)
        {
            var dbCourse = _context.Set<Course>().Find(course.Id);
            if (dbCourse != null)
                _context.Set<Course>().Remove(dbCourse);
        }

        public void Update(DalCourse course)
        {
            var ormCourse = _context.Set<Course>().Find(course.Id);
            ormCourse.Title = course.Title;
            ormCourse.Description = course.Description;
            ormCourse.Published = course.Published;
            ormCourse.Tags = course.TagList.Select(t => new Tag(t)).ToList();
        }

        public IEnumerable<DalCourse> GetAll()
        {
            return _context.Set<Course>().AsEnumerable().Select(c => c.ToDalCourse()).ToList();
        }

        private IList<Tag> DistinctTags(IList<Tag> tags)
        {
            var distinctTags = new List<Tag>();

            foreach (var tag in tags)
            {
                var dbTag = _context.Set<Tag>().FirstOrDefault(t => t.TagField == tag.TagField);
                distinctTags.Add(dbTag ?? tag);
            }

            return distinctTags;
        }
    }
}