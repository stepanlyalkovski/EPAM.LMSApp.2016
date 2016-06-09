using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Courses.Content
{
    public class CodeSample
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Data { get; set; }

        public virtual IList<LessonPage> Pages { get; set; }
    }
}
