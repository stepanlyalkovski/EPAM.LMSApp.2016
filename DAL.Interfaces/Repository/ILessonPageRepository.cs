using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface ILessonPageRepository
    {

        void Add(int lessonId, DalLessonPage page);
        DalLessonPage Get(int pageId);
        IEnumerable<DalLessonPage> GetLessonPages(int lessonId);
        void Update(DalLessonPage page);
        void Remove(int pageId);
        
        void AddImage(int pageId, DalImage image);
        DalImage GetImage(int pageId);
        void RemoveImage(int pageId);
        void AddCodeSample(int pageId, DalCodeSample codeSample);
        DalCodeSample GetCodeSample(int pageId);
        void RemoveCodeSample(int pageId);
        

    }
}