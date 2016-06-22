using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.Repository
{
    public interface ICourseRepository : IRepository<DalCourse>
    {
        DalCourse Get(string title);
        IEnumerable<DalCourse> GetRandom(int number);
        IEnumerable<DalCourse> GetByTags(IEnumerable<string> tags);
        IEnumerable<DalCourse> GetBySubString(string substring);
        IEnumerable<DalCourse> GetStorageCourses(int storageId);
        void AttachModule(DalModule module, DalCourse course);
    }
}
