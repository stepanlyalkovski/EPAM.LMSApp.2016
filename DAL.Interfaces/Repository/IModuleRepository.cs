using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IModuleRepository : IRepository<DalModule>
    {
        IEnumerable<DalModule> GetCourseModules(int courseId);
        DalModule Get(int courseId, string title);

        void AttachLesson(DalLesson lesson, int moduleId);
        void AttachQuiz(DalQuiz quiz, int moduleId);
        void AttachArticle(DalHtmlArticle article, int moduleId);

    }
}