namespace BLL.Interfaces.Entities.Courses.Content
{
    public class HtmlArticleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlData { get; set; }
        public int StorageId { get; set; }
    }
}