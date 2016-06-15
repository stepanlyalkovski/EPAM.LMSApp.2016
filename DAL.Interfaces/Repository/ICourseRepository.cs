using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.Repository
{
    public interface ICourseRepository
    {
        void Add(int storageId, DalCourse course);
        DalCourse Get(string title);
        DalCourse Get(int id);
        IEnumerable<DalCourse> GetStorageCourses(int storageId);
        void Remove(int storageId, DalCourse course);
        void Update(int storageId, DalCourse course);
    }
}
