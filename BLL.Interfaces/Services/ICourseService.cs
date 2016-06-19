using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Services
{
    public interface ICourseService
    {
        CourseEntity GetByTitle(string title);
        CourseEntity Get(int courseId);
        IEnumerable<CourseEntity> GetaAll(); 
        void AddCourse(CourseEntity course);
        IEnumerable<CourseEntity> GetCreatedCourses(int storageId);

        //void AddModule(int courseId, ModuleEntity module);
        //IEnumerable<ModuleEntity> GetModules(int courseId);
        //ModuleEntity GetModule(int courseId, string title);
    }
}