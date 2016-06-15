using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Courses
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagField { get; set; }
        public virtual IList<Course> Courses { get; set; }

        public Tag() { }
        public Tag(string tagField)
        {
            TagField = tagField;
        }
    }
}