using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.DTO.Courses
{
    public class DalLessonPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LessonId { get; set; }

        public string Text { get; set; }
        public int? ImageId { get; set; }
        public int? CodeSampleId { get; set; }
        //public virtual DalImage Image { get; set; }
        //public virtual DalCodeSample CodeSample { get; set; }
    }
}