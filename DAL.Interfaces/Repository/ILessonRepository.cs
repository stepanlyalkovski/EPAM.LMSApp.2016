using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface ILessonRepository : IRepository<DalLesson>
    {
        DalLesson GetModuleLesson(int moduleId);
        void AttachPage(DalLessonPage page, DalLesson lesson);
    }
}