﻿using System;
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

        public ImageEntity GetImage(int id)
        {
            return _uow.Images.Get(id).ToImageEntity();
        }

        public ImageEntity GetImage(string path)
        {
            return _uow.Images.Get(path).ToImageEntity();
        }

        public bool ImageInUse(int imageId)
        {
            var image = _uow.Images.Get(imageId);
            var storage = _uow.Storages.Get(image.StorageId);
            var courses = _uow.Courses.GetStorageCourses(storage.UserId);
            foreach (var course in courses)
            {
                var modules = _uow.Modules.GetCourseModules(course.Id);
                foreach (var module in modules)
                {
                    var lesson = _uow.Lessons.GetModuleLesson(module.Id);
                    if (lesson == null) continue;

                    var pages = _uow.LessonPages.GetLessonPages(lesson.Id);

                    if (pages.Any(page => page.ImageId == imageId))
                    {
                        return true;
                    }
                }
            }

            return false;
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

        public HtmlArticleEntity GetHtmlArticle(int id)
        {
           return  _uow.Articles.Get(id).ToHtmlArticleEntity();
        }

        public void UpdateHtmlArticle(HtmlArticleEntity article)
        {
            _uow.Articles.Update(article.ToDalHtmlArticle());
            _uow.Complete();
        }

        public IEnumerable<HtmlArticleEntity> GetHtmlArticles(int storageId)
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