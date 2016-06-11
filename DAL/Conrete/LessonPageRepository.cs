using System.Data.Entity;
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

        public void SetText(int pageId, string text)
        {
            _context.Set<LessonPage>().Find(pageId).Text = text;
        }

    }
}