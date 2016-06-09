using System.Collections.Generic;

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