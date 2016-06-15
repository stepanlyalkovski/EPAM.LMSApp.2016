namespace BLL.Interfaces.Entities.Courses
{
    public class EnrolmentEntity
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }
        public int CourseId { get; set; }

        public bool CourseCompleted { get; set; }
    }
}