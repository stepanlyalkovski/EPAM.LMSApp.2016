using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Services
{
    public interface ICourseService
    {
        CourseEntity GetByTitle(string title);
        CourseEntity Get(int courseId);
        IEnumerable<CourseEntity> GetRandom(int number);
        void Remove(CourseEntity course);
        void Update(CourseEntity course);
        IEnumerable<CourseEntity> GetaAll(); 
        void AddCourse(CourseEntity course);
        IEnumerable<CourseEntity> GetCreatedCourses(int storageId);
        IEnumerable<CourseEntity> SearchBySubstring(string name);
        IEnumerable<CourseEntity> SearchByTags(IList<string> tags);
        IEnumerable<CourseEntity> Search(string name = null, IList<string> tags = null);
        //void AddModule(int courseId, ModuleEntity module);
        //IEnumerable<ModuleEntity> GetModules(int courseId);
        //ModuleEntity GetModule(int courseId, string title);
    }
}