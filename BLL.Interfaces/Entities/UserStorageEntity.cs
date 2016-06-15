using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses;

namespace BLL.Interfaces.Entities
{
    public class UserStorageEntity
    {
        public int UserId { get; set; }
        public string StorageName { get; set; }

        //public DalUser User { get; set; }
        // TODO Mapping
        public IList<CourseEntity> Courses { get; set; } 
    }
}