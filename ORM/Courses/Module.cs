using System.Collections.Generic;
using ORM.Courses.Content;

namespace ORM.Courses
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual IList<HtmlArticle> HtmlArticles { get; set; }

        public virtual IList<Course> Courses { get; set; }
        public virtual IList<CourseProgress> CourseProgress { get; set; }
    }
}