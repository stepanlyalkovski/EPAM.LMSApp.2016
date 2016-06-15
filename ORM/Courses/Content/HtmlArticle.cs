using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("UserStorage")]
        public int StorageId { get; set; }
        public virtual UserStorage UserStorage { get; set; }
    }
}
