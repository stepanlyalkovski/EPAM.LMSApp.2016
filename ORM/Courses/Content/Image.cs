using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Courses.Content
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; }
        [ForeignKey("UserStorage")]
        public int StorageId { get; set; }
        public virtual UserStorage UserStorage { get; set; }
        public virtual IList<LessonPage> Pages { get; set; }
    }
}