using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public void Add(DalQuiz quiz)
        {
            _context.Set<Quiz>().Add(quiz.ToOrmQuiz());
        }

        public DalQuiz Get(int quizId)
        {
            return _context.Set<Quiz>().Find(quizId).ToDalQuiz();
        }

        public DalQuiz GetModuleQuiz(int moduleId)
        {
            return _context.Set<Module>().Find(moduleId).Quiz.ToDalQuiz();
        }

        public IEnumerable<DalQuiz> GetStorageQuizzes(int storageId)
        {
           return _context.Set<Quiz>().Where(q => q.StorageId == storageId).AsEnumerable().Select(q => q.ToDalQuiz()).ToList();
        }

        public void Remove(DalQuiz quiz)
        {
            var ormQuiz = _context.Set<Quiz>().Find(quiz.Id);
            if (ormQuiz != null)
                _context.Set<Quiz>().Remove(ormQuiz);
        }

        public void Update(DalQuiz quiz)
        {
            var ormQuiz = _context.Set<Quiz>().Find(quiz.Id);
            ormQuiz.DataFilePath = quiz.DataFilePath;
            ormQuiz.Title = quiz.Title;
        }

        public IEnumerable<DalQuiz> GetAll()
        {
            return _context.Set<Quiz>().Select(q => q.ToDalQuiz());
        }
    }
}