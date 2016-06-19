using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Entities.Courses.Content;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class StorageService : IStorageService
    {
        private readonly IUnitOfWork _uow;

        public StorageService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserStorageEntity GetStorage(int id)
        {
            return _uow.Storages.Get(id).ToUserStorageEntity();
        }

        public void AddImage(ImageEntity image)
        {           
            _uow.Images.Add(image.ToDalImage());
            _uow.Complete();
        }

        public IEnumerable<ImageEntity> GetImages(int storageId)
        {
            return _uow.Images.GetStorageImages(storageId).Select(im => im.ToImageEntity()).ToList();
        }

        public void RemoveImage(ImageEntity image)
        {
            _uow.Images.Remove(image.ToDalImage());
            _uow.Complete();
        }

        public void AddCodeSample(CodeSampleEntity code)
        {
            _uow.CodeSamples.Add(code.ToDalCodeSample());
            _uow.Complete();
        }

        public IEnumerable<CodeSampleEntity> GetCodeSamples(int storageId)
        {
            return _uow.CodeSamples.GetStorageCodeSamples(storageId).Select(c => c.ToCodeSampleEntity()).ToList();
        }

        public void RemoveCodeSample(CodeSampleEntity code)
        {
            _uow.CodeSamples.Remove(code.ToDalCodeSample());
            _uow.Complete();
        }

        public void AddQuiz(QuizEntity quiz)
        {
            _uow.Quizzes.Add(quiz.ToDalQuiz());
            _uow.Complete();
        }

        public IEnumerable<QuizEntity> GetQuizess(int storageId)
        {
            return _uow.Quizzes.GetStorageQuizzes(storageId).Select(q => q.ToQuizEntity()).ToList();
        }

        public void RemoveQuiz(QuizEntity quiz)
        {
            _uow.Quizzes.Remove(quiz.ToDalQuiz());
            _uow.Complete();
        }

        public void AddHtmlArticle(HtmlArticleEntity article)
        {
            _uow.Articles.Add(article.ToDalHtmlArticle());
            _uow.Complete();
        }

        public IEnumerable<HtmlArticleEntity> GetArticles(int storageId)
        {
            return _uow.Articles.GetStorageArticles(storageId).Select(a => a.ToHtmlArticleEntity()).ToList();
        }

        public void RemoveHtmlArticle(HtmlArticleEntity article)
        {
            _uow.Articles.Remove(article.ToDalHtmlArticle());
            _uow.Complete();
        }
    }
}