using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IModuleRepository : IRepository<DalModule>
    {
        void AddQuiz(int moduleId, DalQuiz quiz);
        void AddArticle(int moduleId, DalHtmlArticle article);
        void AddLesson(int moduleId, DalLesson lesson);
        DalLesson GetLesson(int moduleId);
    }
}