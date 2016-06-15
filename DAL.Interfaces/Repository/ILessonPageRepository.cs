using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface ILessonPageRepository : IRepository<DalLessonPage>
    {
        IEnumerable<DalLessonPage> GetLessonPages(int lessonId);
    }
}