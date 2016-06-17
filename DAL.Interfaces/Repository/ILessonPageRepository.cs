using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface ILessonPageRepository : IRepository<DalLessonPage>
    {
        IEnumerable<DalLessonPage> GetLessonPages(int lessonId);

        void AttachImage(DalImage image, int pageId);
        void AttachCodeSample(DalCodeSample code, int pageId);
    }
}