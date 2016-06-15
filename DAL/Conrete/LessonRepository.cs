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

namespace DAL.Conrete
{
    public class LessonRepository : ILessonRepository
    {
        private readonly DbContext _context;

        public LessonRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(int moduleId, DalLesson lesson)
        {
            var ormModule = _context.Set<Module>().Find(moduleId);
            if (ormModule.Lesson != null)
                throw new OperationCanceledException("Lesson is already exist in current module ");
            ormModule.Lesson = lesson.ToOrmLesson();
        }

        public DalLesson Get(int id)
        {
            return _context.Set<Lesson>().Include(l => l.Pages.Select(p => p.Image))
                                               .Include(l => l.Pages.Select(p => p.CodeSample))
                                              .FirstOrDefault(l => l.Id == id).ToDalLesson();        
        }

        public void Update(DalLesson lesson)
        {
            var ormLesson = _context.Set<Lesson>().Find(lesson.Id);
            ormLesson.Title = lesson.Title;
            ormLesson.Description = lesson.Description;
        }

        public void Remove(int lessonId)
        {
            var lesson = _context.Set<Lesson>().Find(lessonId);
            _context.Set<Lesson>().Remove(lesson);
        }
    }
}