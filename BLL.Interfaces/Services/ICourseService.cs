using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Services
{
    public interface ICourseService
    {
        CourseEntity GetByTitle(string title);
        CourseEntity Get(int courseId);
        void AddModule(int courseId, ModuleEntity module);
        IEnumerable<ModuleEntity> GetModules(int courseId);
        ModuleEntity GetModule(int courseId, string title);
    }
}