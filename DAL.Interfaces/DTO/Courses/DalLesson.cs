using System.Collections.Generic;

namespace DAL.Interfaces.DTO.Courses
{
    public class DalLesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        //public virtual IList<DalModule> Modules { get; set; }
        //public virtual IList<DalLessonPage> Pages { get; set; }
    }
}