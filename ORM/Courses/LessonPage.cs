using ORM.Courses.Content;

namespace ORM.Courses
{
    public class LessonPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LessonId { get; set; }
        public int? CodeSampleId { get; set; }
        public int? ImageId { get; set; }
        public string Text { get; set; }
        public virtual Image Image { get; set; }
        public virtual CodeSample CodeSample { get; set; }
    }
}