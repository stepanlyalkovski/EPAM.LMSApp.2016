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

        public void Add(DalLesson lesson)
        {
            if (lesson != null)
                _context.Set<Lesson>().Add(lesson.ToOrmLesson());
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

        public IEnumerable<DalLesson> GetAll()
        {
            return _context.Set<Lesson>().Select(l => l.ToDalLesson());
        }

        public DalLesson GetModuleLesson(int moduleId)
        {
            return _context.Set<Module>().Find(moduleId).Lesson.ToDalLesson();
        }

        public void AttachPage(DalLessonPage page, DalLesson lesson)
        {
            var localLesson = _context.Set<Lesson>().Local.First(l => l.Title == lesson.Title
                                                                 && l.PageCount == lesson.PageCount);
            if(localLesson.Pages == null)
                localLesson.Pages = new List<LessonPage>();
            localLesson.Pages.Add(page.ToOrmLessonPage());
        }

        public void Remove(DalLesson lesson)
        {
            var ormLesson = _context.Set<Lesson>().Find(lesson.Id);
            _context.Set<Lesson>().Remove(ormLesson);
        }
    }
}