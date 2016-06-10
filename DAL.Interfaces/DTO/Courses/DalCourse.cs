using System.Collections.Generic;

namespace DAL.Interfaces.DTO.Courses
{
    public class DalCourse : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public bool Published { get; set; }

        public virtual IList<DalModule> Modules { get; set; }
        public virtual IList<DalEnrolment> Enrolment { get; set; }
        //public virtual DalUserStorage UserStorage { get; set; }
        public virtual IList<DalTag> Tags { get; set; }
    }
}