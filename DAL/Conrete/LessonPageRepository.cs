using System.Collections.Generic;
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

        public void Add(int lessonId, DalLessonPage page)
        {
            var ormLesson = _context.Set<Lesson>().Find(lessonId);
            page.LessonId = ormLesson.Id;
            _context.Set<LessonPage>().Add(page.ToOrmLessonPage());
        }

        public DalLessonPage Get(int pageId)
        {
            return _context.Set<LessonPage>().Find(pageId).ToDalLessonPage();
        }

        public IEnumerable<DalLessonPage> GetLessonPages(int lessonId)
        {
            return _context.Set<Lesson>().Find(lessonId).Pages.Select(p => p.ToDalLessonPage());
        }

        public void Update(DalLessonPage page)
        {
            var ormPage = _context.Set<LessonPage>().Find(page.Id);
            ormPage.Title = page.Title;
            ormPage.Text = ormPage.Text;

        }

        public void Remove(int pageId)
        {
            var page = _context.Set<LessonPage>().Find(pageId);
            if (page != null)
                _context.Set<LessonPage>().Remove(page);
        }      

        public void AddImage(int pageId, DalImage image)
        {
            _context.Set<LessonPage>().Find(pageId).Image = image.ToOrmImage();
        }

        public DalImage GetImage(int pageId)
        {
            return _context.Set<LessonPage>().Find(pageId).Image.ToDalImage();
        }

        public void RemoveImage(int pageId)
        {
            var image = _context.Set<LessonPage>().Find(pageId).Image;
            _context.Set<Image>().Remove(image);
        }

        public void AddCodeSample(int pageId, DalCodeSample codeSample)
        {
            _context.Set<LessonPage>().Find(pageId).CodeSample = codeSample.ToOrmCodeSample();
        }

        public void RemoveCodeSample(int pageId)
        {
            var code = _context.Set<LessonPage>().Find(pageId).CodeSample;
            _context.Set<CodeSample>().Remove(code);
        }

        public DalCodeSample GetCodeSample(int pageId)
        {
            return _context.Set<LessonPage>().Find(pageId).CodeSample.ToDalCodeSample();
        }

    }
}