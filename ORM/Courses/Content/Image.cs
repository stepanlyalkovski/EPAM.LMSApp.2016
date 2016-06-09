using System.Collections.Generic;

namespace ORM.Courses.Content
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; }

        public virtual IList<LessonPage> Pages { get; set; }
    }
}