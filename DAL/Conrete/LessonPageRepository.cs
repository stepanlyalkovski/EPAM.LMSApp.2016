﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM.Courses;
using ORM.Courses.Content;

namespace DAL.Conrete
{
    public class LessonPageRepository : ILessonPageRepository
    {
        private readonly DbContext _context;

        public LessonPageRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(DalLessonPage page)
        {
            _context.Set<LessonPage>().Add(page.ToOrmLessonPage());
            _context.Set<Lesson>().Find(page.LessonId).PageCount++;
        }

        public DalLessonPage Get(int pageId)
        {
            return _context.Set<LessonPage>().Find(pageId).ToDalLessonPage();
        }

        public IEnumerable<DalLessonPage> GetLessonPages(int lessonId)
        {
            return _context.Set<Lesson>().Find(lessonId).Pages.Select(p => p.ToDalLessonPage());
        }

        public void AttachImage(DalImage image, int pageId)
        {
            var ormPage = _context.Set<LessonPage>().Find(pageId);
            var ormImage = _context.Set<Image>().Find(image.Id);
            ormPage.Image = ormImage;
        }

        public void AttachCodeSample(DalCodeSample code, int pageId)
        {
            _context.Set<LessonPage>().Find(pageId).CodeSampleId = code.Id;
        }

        public void Update(DalLessonPage page)
        {
            var ormPage = _context.Set<LessonPage>().Find(page.Id);
            ormPage.Title = page.Title;
            ormPage.Text = ormPage.Text;

        }

        public IEnumerable<DalLessonPage> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(DalLessonPage page)
        {
            _context.Set<Lesson>().Find(page.LessonId).PageCount--;
            var ormPage = _context.Set<LessonPage>().Find(page.Id);
            if (ormPage != null)
                _context.Set<LessonPage>().Remove(ormPage);
            
        }      

    }
}