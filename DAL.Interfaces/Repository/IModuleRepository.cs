using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IModuleRepository
    {
        void Add(int courseId, DalModule module);
        IEnumerable<DalModule> GetCourseModules(int courseId);
        DalModule Get(int courseId, string title);
        DalModule Get(int moduleId);
        void Update(DalModule module);
        void Remove(int moduleId);   
    }
}