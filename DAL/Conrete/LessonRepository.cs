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
        public DalLesson Get(int id)
        {
            return _context.Set<Lesson>().Include(l => l.Pages.Select(p => p.Image))
                                               .Include(l => l.Pages.Select(p => p.CodeSample))
                                               .FirstOrDefault(l => l.Id == id).ToDalLesson();        
        }

        public IEnumerable<DalLesson> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalLesson> Find(Expression<Func<DalLesson, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(DalLesson entity)
        {
            _context.Set<Lesson>().Add(entity.ToOrmLesson());
        }

        public void AddRange(IEnumerable<DalLesson> entities)
        {
            _context.Set<Lesson>().AddRange(entities.Select(e => e.ToOrmLesson()));
        }

        public void Remove(DalLesson entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<DalLesson> entities)
        {
            throw new NotImplementedException();
        }

        public void AddPage(int lessonId, DalLessonPage page)
        {
            var ormLesson = _context.Set<Lesson>().Find(lessonId);
            page.LessonId = ormLesson.Id;
            _context.Set<LessonPage>().Add(page.ToOrmLessonPage());
        }

        public IEnumerable<DalLessonPage> GetPages(int lessonId)
        {
            //var ormLesson =_context.Set<Lesson>().Find(lesson.Id);
            return _context.Set<Lesson>().Include(l => l.Pages)
                                        .FirstOrDefault(l => l.Id == lessonId)
                                        ?.Pages.Select(p => p.ToDalLessonPage());
        }

        public void AddImage(int pageId, DalImage image)
        {
            //var ormPage = _context.Set<LessonPage>().Include(p => p.Image).FirstOrDefault(p => p.Id == pageId);
            _context.Set<LessonPage>().Find(pageId).Image = image.ToOrmImage();
        }

        public void AddCodeSample(int pageId, DalCodeSample codeSample)
        {
            _context.Set<LessonPage>().Find(pageId).CodeSample = codeSample.ToOrmCodeSample();
        }

        public void SetText(int pageId, string text)
        {
            _context.Set<LessonPage>().Find(pageId).Text = text;
        }
    }
}