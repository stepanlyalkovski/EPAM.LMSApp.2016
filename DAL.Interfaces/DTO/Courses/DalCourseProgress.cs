namespace DAL.Interfaces.DTO.Courses
{
    public class DalCourseProgress
    {

        public int Id { get; set; }

        //public int EnrolmentId { get; set; }

        //public int ModuleId { get; set; }

        public bool LessonCompleted { get; set; }
        public bool QuizCompleted { get; set; }

        public virtual DalEnrolment Enrolment { get; set; }
        public virtual DalModule Module { get; set; }
    }
}