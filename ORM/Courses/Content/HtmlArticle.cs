using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Courses.Content
{
    public class HtmlArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlData { get; set; }

        public virtual IList<Module> Modules { get; set; }

    }
}
