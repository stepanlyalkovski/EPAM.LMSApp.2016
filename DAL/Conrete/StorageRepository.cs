using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;
using ORM.Courses;

namespace DAL.Conrete
{
    public class StorageRepository : IStorageRepository
    {
        private readonly DbContext _context;

        public StorageRepository(DbContext context)
        {
            _context = context;
        }
        public void AddCourse(int storageId, DalCourse course)
        {
            var storage = _context.Set<UserStorage>().Find(storageId);
            var courses = storage.Courses ?? new List<Course>();
            Course ormCourse = course.ToOrmCourse();
            for (int i = 0; i < ormCourse.Tags.Count; i++)
            {
                var tag = ormCourse.Tags[i];
                var dbTag = _context.Set<Tag>().FirstOrDefault(t => t.TagField == tag.TagField);

                if (dbTag != null)
                {
                    ormCourse.Tags.Remove(tag);
                    ormCourse.Tags.Add(dbTag);
                }
            }
            courses.Add(ormCourse);
            storage.Courses = courses;
        }

        public IEnumerable<DalCourse> GetCreatedCourses(int storageId)
        {
            return _context.Set<UserStorage>().Find(storageId).Courses.ToDalCourses();
        }

        public void RemoveCourse(int storageId, DalCourse course)
        {
            var dbCourse = _context.Set<UserStorage>().Find(storageId).Courses.FirstOrDefault(c => c.Id == course.Id);
            if(dbCourse != null)
                _context.Set<Course>().Remove(dbCourse);
        }

        public void UpdateCourse(int storageId, DalCourse course)
        {
            var ormCourse = _context.Set<Course>().Find(course.Id);
            ormCourse.Title = course.Title;
            ormCourse.Description = course.Description;
            ormCourse.Published = course.Published;
            ormCourse.Tags = course.TagList.Select(t => new Tag(t)).ToList();
        }
    }
}