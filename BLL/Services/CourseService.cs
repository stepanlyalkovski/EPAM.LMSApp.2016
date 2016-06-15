using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;
using BLL.Interfaces.Services;

namespace BLL.Services
{
    public class CourseService : ICourseService
    {
        public CourseEntity GetByTitle(string title)
        {
            throw new System.NotImplementedException();
        }

        public CourseEntity Get(int courseId)
        {
            throw new System.NotImplementedException();
        }

        public void AddModule(int courseId, ModuleEntity module)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ModuleEntity> GetModules(int courseId)
        {
            throw new System.NotImplementedException();
        }

        public ModuleEntity GetModule(int courseId, string title)
        {
            throw new System.NotImplementedException();
        }
    }
}