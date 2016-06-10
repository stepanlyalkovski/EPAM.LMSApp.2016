using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface ILessonRepository : IRepository<DalLesson>
    {
        void AddPage(int lessonId, DalLessonPage page);
        IEnumerable<DalLessonPage> GetPages(int lessonId);
        void AddImage(int pageId, DalImage image);
        void AddCodeSample(int pageId, DalCodeSample codeSample);
        void SetText(int pageId, string text);
    }
}