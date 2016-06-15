namespace BLL.Interfaces.Entities.Courses
{
    public class LessonPageEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LessonId { get; set; }

        public string Text { get; set; }
        public int? ImageId { get; set; }
        public int? CodeSampleId { get; set; }
    }
}