using System.Collections.Generic;

namespace BLL.Interfaces.Entities.Courses
{
    public class ModuleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public int? QuizId { get; set; }
        public int? LessonId { get; set; }
        //public virtual DalLesson Lesson { get; set; }
        //public virtual DalQuiz Quiz { get; set; }
        //public virtual IList<DalHtmlArticle> HtmlArticles { get; set; }

        //public virtual IList<DalCourseProgress> CourseProgress { get; set; }
    }
}