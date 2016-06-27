using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _uow;

        public CourseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public CourseEntity GetByTitle(string title)
        {
            return _uow.Courses.Get(title).ToBllCourseEntity();
            
        }

        public CourseEntity Get(int courseId)
        {
            var bllCourse = _uow.Courses.Get(courseId).ToBllCourseEntity();
            bllCourse.Author = GetAuthorName(bllCourse.UserStorageId); // note that UserStorageID = UserID = profileID
            return bllCourse;
        }

        public IEnumerable<CourseEntity> GetRandom(int number)
        {
            var courses =  _uow.Courses.GetRandom(number).Select(c => c.ToBllCourseEntity()).ToList();
            foreach (var course in courses)
            {
                course.Author = GetAuthorName(course.UserStorageId);
            }
            return courses;
        }

        public void Remove(CourseEntity course)
        {
            var modules = _uow.Modules.GetCourseModules(course.Id).ToList();
            foreach (var module in modules)
            {
                var lesson = _uow.Lessons.GetModuleLesson(module.Id);
                if(lesson != null)
                    _uow.Lessons.Remove(lesson);

                var quiz = _uow.Quizzes.GetModuleQuiz(module.Id);
                if(quiz != null)
                    _uow.Quizzes.Remove(quiz);
            }
            for (int i = 0; i < modules.Count; i++)
            {
                _uow.Modules.Remove(modules[i]);
            }        
            _uow.Courses.Remove(course.ToDalCourse());
            _uow.Complete();
        }

        public void Update(CourseEntity course)
        {
            if (course.TagList != null)
                course.TagList = course.TagList.Distinct().ToList();
            _uow.Courses.Update(course.ToDalCourse());
            _uow.Complete();
        }

        public IEnumerable<CourseEntity> GetaAll()
        {
           var courses = _uow.Courses.GetAll().Select(c => c.ToBllCourseEntity()).ToList();

            foreach (var course in courses)
            {
                course.Author = GetAuthorName(course.UserStorageId);
            }

            return courses;
        }

        public void AddCourse(CourseEntity course)
        {
            var dalCourse = course.ToDalCourse();
            _uow.Courses.Add(dalCourse);
            int modules = course.ModulesNumber;

            for (int i = 1; i < modules + 1; i++)
            {
                var emptyModule = new DalModule {Title = $"Chapter {i}", Description = $"Chapter {i} Description" };
                _uow.Courses.AttachModule(emptyModule, dalCourse);
            }
            _uow.Complete();
        }

        public IEnumerable<CourseEntity> GetCreatedCourses(int storageId)
        {
           return _uow.Courses.GetStorageCourses(storageId).Select(c => c.ToBllCourseEntity());
        }

        public IEnumerable<CourseEntity> SearchBySubstring(string name)
        {
           var courses = _uow.Courses.GetBySubString(name).Select(c => c.ToBllCourseEntity()).ToList();

            foreach (var course in courses)
            {
                course.Author = GetAuthorName(course.UserStorageId);
            }
            return courses;
        }

        public IEnumerable<CourseEntity> SearchByTags(IList<string> tags)
        {
            var courses = _uow.Courses.GetByTags(tags).Select(c => c.ToBllCourseEntity()).ToList();

            foreach (var course in courses)
            {
                course.Author = GetAuthorName(course.UserStorageId);
            }
            return courses;
        }

        public IEnumerable<CourseEntity> Search(string name, IList<string> tags = null)
        {
            if (String.IsNullOrEmpty(name) && (tags == null || tags.Count == 0))
                return null;

            if (String.IsNullOrEmpty(name))
                return SearchByTags(tags);

            if (tags == null || tags.Count == 0)
                return SearchBySubstring(name);

            var tagSearchResult = SearchByTags(tags).ToList();
            var nameSearchResult = SearchBySubstring(name).ToList();
            var searchResult = new List<CourseEntity>();
            foreach (var courseByName in nameSearchResult)
            {
                searchResult.AddRange(tagSearchResult.Where(courseByTag => courseByName.Id == courseByTag.Id));
            }

            return searchResult.ToList();
        }

        private string GetAuthorName(int profileId)
        {
            var authorProfile = _uow.Profiles.Get(profileId);

            if (authorProfile.LastName == null)
                return "Anonymous";

            return authorProfile.FirstName + " " + authorProfile.LastName;
        }
    }
}