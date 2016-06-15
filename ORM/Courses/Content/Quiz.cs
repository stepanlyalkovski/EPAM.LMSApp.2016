using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Courses.Content
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DataFilePath { get; set; }
        [ForeignKey("UserStorage")]
        public int StorageId { get; set; }
        public virtual UserStorage UserStorage { get; set; }
    }
}