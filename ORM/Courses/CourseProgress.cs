using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Courses
{
    public class CourseProgress
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Enrolment")]
        public int EnrolmentId { get; set; }
        [ForeignKey("Module")]
        public int ModuleId { get; set; }

        public bool LessonCompleted { get; set; }
        public bool QuizCompleted { get; set; }

        public virtual Enrolment Enrolment { get; set; }
        public virtual Module Module { get; set; }


    }
}