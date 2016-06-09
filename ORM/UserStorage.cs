using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ORM.Courses;

namespace ORM
{
    public class UserStorage
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string StorageName { get; set; }

        public virtual User User { get; set; }
        public virtual IList<Course> Courses { get; set; }

    }
}