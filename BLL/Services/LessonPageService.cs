using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Entities.Courses.Content;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class LessonPageService : ILessonPageService
    {
        private readonly IUnitOfWork _uow;

        public LessonPageService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Add(LessonPageEntity page)
        {
            _uow.LessonPages.Add(page.ToDalLessonPage());
            _uow.Complete();
        }

        public void Remove(LessonPageEntity page)
        {
            _uow.LessonPages.Add(page.ToDalLessonPage());
        }

        public void Update(LessonPageEntity page)
        {
            _uow.LessonPages.Update(page.ToDalLessonPage());
        }

        public LessonPageEntity Get(int pageId)
        {
            return _uow.LessonPages.Get(pageId).ToLessonPageEntity();
        }

        public IEnumerable<LessonPageEntity> GetLessonPages(int lessonId)
        {
            return _uow.LessonPages.GetLessonPages(lessonId).Select(p => p.ToLessonPageEntity()).ToList();
        }

        public LessonPageFullEntity GetFullPage(int pageId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LessonPageFullEntity> GetFullPages(int lessonId)
        {
            var pages = _uow.LessonPages.GetLessonPages(lessonId).Select(p => p.ToLessonPageEntity()).ToList();
            IList<LessonPageFullEntity> fullPages = new List<LessonPageFullEntity>();

            foreach (var page in pages)
            {               
                var image = _uow.Images.GetPageImage(page.Id).ToImageEntity();
                var codeSample = _uow.CodeSamples.GetPageCodeSample(page.Id).ToCodeSampleEntity();
                var fullPage = new LessonPageFullEntity {PageInfo = page, Image = image, CodeSample = codeSample};
                fullPages.Add(fullPage);
            }

            return fullPages;
        }

        public void AttachImage(ImageEntity image, int pageId)
        {
            _uow.LessonPages.AttachImage(image.ToDalImage(), pageId);
        }

        public void AttachCodeSample(CodeSampleEntity code, int pageId)
        {
            _uow.LessonPages.AttachCodeSample(code.ToDalCodeSample(), pageId);
        }
    }
}