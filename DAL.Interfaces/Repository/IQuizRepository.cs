using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IQuizRepository
    {
        void Add(int moduleId, DalQuiz quiz);
        DalQuiz Get(int quizId);
        DalQuiz GetModuleQuiz(int moduleId);
        void Remove(int quizId);
        void Update(DalQuiz quiz);
    }
}