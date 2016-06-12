using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface ILessonPageRepository
    {
        void AddImage(int pageId, DalImage image);
        void AddCodeSample(int pageId, DalCodeSample codeSample);
        void Update(DalLessonPage page);
        DalImage GetImage(int pageId);
        void RemoveImage(int pageId);
        void RemoveCodeSample(int pageId);
        DalCodeSample GetCodeSample(int pageId);

    }
}