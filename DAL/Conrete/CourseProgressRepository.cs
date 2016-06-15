using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM.Courses;

namespace DAL.Conrete
{
    public class CourseProgressRepository : ICourseProgressRepository
    {
        private readonly DbContext _context;

        public CourseProgressRepository(DbContext context)
        {
            _context = context;
        }

        public DalCourseProgress Get(int id)
        {
           return _context.Set<CourseProgress>().Find(id).ToDalCourseProgress();
        }

        public void Add(DalCourseProgress entity)
        {
            _context.Set<CourseProgress>().Add(entity.ToOrmCourseProgress());
        }

        public void Remove(DalCourseProgress entity)
        {
            var ormProgress = _context.Set<CourseProgress>().Find(entity.Id);
            _context.Set<CourseProgress>().Remove(ormProgress);
        }

        public void Update(DalCourseProgress entity)
        {
           var ormProgress = _context.Set<CourseProgress>().Find(entity.Id);
            ormProgress.LessonCompleted = entity.LessonCompleted;
            ormProgress.QuizCompleted = entity.QuizCompleted;
        }

        public IEnumerable<DalCourseProgress> GetAll()
        {
            return _context.Set<CourseProgress>().Select(p => p.ToDalCourseProgress()).ToList();
        }
    }
}