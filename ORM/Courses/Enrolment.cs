using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ORM.Courses;

namespace ORM
{
    public class Enrolment
    {
        public int Id { get; set; }

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public bool CourseCompleted { get; set; }

        public virtual IList<CourseProgress> Progress { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Course Course { get; set; }
    }
}