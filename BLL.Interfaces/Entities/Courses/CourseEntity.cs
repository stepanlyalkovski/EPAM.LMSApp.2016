using System.Collections.Generic;

namespace BLL.Interfaces.Entities.Courses
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public int ModulesNumber { get; set; }
        public int UserStorageId { get; set; }
        public string Author { get; set; }
        //public virtual IList<ModuleEntity> Modules { get; set; }
        //public virtual IList<DalEnrolment> Enrolment { get; set; }
        //public virtual DalUserStorage UserStorage { get; set; }
        public IList<string> TagList { get; set; }
    }
}