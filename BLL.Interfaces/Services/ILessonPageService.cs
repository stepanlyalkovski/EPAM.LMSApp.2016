using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Entities.Courses.Content;

namespace BLL.Interfaces.Services
{
    public interface ILessonPageService
    {
        void Add(LessonPageEntity page);
        void Remove(LessonPageEntity page);
        void Update(LessonPageEntity page);
        LessonPageEntity Get(int pageId);
        IEnumerable<LessonPageEntity> GetLessonPages(int lessonId);

        LessonPageFullEntity GetFullPage(int pageId);
        IEnumerable<LessonPageFullEntity> GetFullPages(int lessonId);
        void AttachImage(ImageEntity image, int pageId);
        void AttachCodeSample(CodeSampleEntity code, int pageId);
    }
}