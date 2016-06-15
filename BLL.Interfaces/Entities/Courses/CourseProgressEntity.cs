namespace BLL.Interfaces.Entities.Courses
{
    public class CourseProgressEntity
    {
        public int Id { get; set; }

        public int EnrolmentId { get; set; }
        public int ModuleId { get; set; }

        public bool LessonCompleted { get; set; }
        public bool QuizCompleted { get; set; }
    }
}