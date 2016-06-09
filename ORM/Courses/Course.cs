using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Courses
{
    public class Course
    {
        public int Id { get; set; }
        [ForeignKey("UserStorage")]
        public int UserStorageId { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }

        public virtual IList<Module> Modules { get; set; }
        public virtual IList<Enrolment> Enrolment { get; set; }
        public virtual UserStorage UserStorage { get; set; }
        public virtual IList<Tag> Tags { get; set; }
    }
}
