using System.Collections.Generic;

namespace ORM.Courses
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public virtual IList<Module> Modules { get; set; }
        public virtual IList<LessonPage> Pages { get; set; }
    }
}