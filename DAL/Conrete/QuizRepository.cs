using System;
using System.Data.Entity;
using DAL.Interfaces.DTO.Courses.Content;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM.Courses;
using ORM.Courses.Content;

namespace DAL.Conrete
{
    public class QuizRepository : IQuizRepository
    {
        private readonly DbContext _context;

        public QuizRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(int moduleId, DalQuiz quiz)
        {
            var ormModule = _context.Set<Module>().Find(moduleId);
            if (ormModule.Quiz != null)
                throw new OperationCanceledException("Quiz is already exist");
            ormModule.Quiz = quiz.ToOrmQuiz();
        }

        public DalQuiz Get(int quizId)
        {
            return _context.Set<Quiz>().Find(quizId).ToDalQuiz();
        }

        public DalQuiz GetModuleQuiz(int moduleId)
        {
            return _context.Set<Module>().Find(moduleId).Quiz.ToDalQuiz();
        }

        public void Remove(int quizId)
        {
            var quiz = _context.Set<Quiz>().Find(quizId);
            if (quiz != null)
                _context.Set<Quiz>().Remove(quiz);
        }

        public void Update(DalQuiz quiz)
        {
            var ormQuiz = _context.Set<Quiz>().Find(quiz.Id);
            ormQuiz.DataFilePath = quiz.DataFilePath;
            ormQuiz.Title = quiz.Title;
        }
    }
}