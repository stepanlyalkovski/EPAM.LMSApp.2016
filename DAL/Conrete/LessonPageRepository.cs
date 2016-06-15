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

        public void Add(DalLessonPage page)
        {
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

        public IEnumerable<DalLessonPage> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(DalLessonPage page)
        {
            var ormPage = _context.Set<LessonPage>().Find(page.Id);
            if (ormPage != null)
                _context.Set<LessonPage>().Remove(ormPage);
        }      

    }
}