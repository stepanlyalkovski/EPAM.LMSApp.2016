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
        DalCourse GetByTitle(string title);
        void AddModule(int courseId, DalModule module);

    }
}
