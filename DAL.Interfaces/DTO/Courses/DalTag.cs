using System.Collections.Generic;

namespace DAL.Interfaces.DTO.Courses
{
    public class DalTag
    {
        public int Id { get; set; }
        public string TagField { get; set; }
        //public virtual IList<DalCourse> Courses { get; set; }

        public DalTag() { }
        public DalTag(string tagField)
        {
            TagField = tagField;
        }
    }
}