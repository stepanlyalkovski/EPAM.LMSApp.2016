using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.DTO.Courses
{
    public class DalModule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual DalLesson Lesson { get; set; }
        public virtual DalQuiz Quiz { get; set; }
        public virtual IList<DalHtmlArticle> HtmlArticles { get; set; }

        public virtual IList<DalCourseProgress> CourseProgress { get; set; }
    }
}