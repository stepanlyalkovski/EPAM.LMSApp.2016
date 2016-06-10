using System.Collections.Generic;
namespace DAL.Interfaces.DTO.Courses
{
    public class DalEnrolment
    {
        public int Id { get; set; }

        //public int ProfileId { get; set; }
        //public int CourseId { get; set; }

        public bool CourseCompleted { get; set; }

        public virtual IList<DalCourseProgress> Progress { get; set; }
        public virtual DalProfile Profile { get; set; }
        public virtual DalCourse Course { get; set; }
    }
}