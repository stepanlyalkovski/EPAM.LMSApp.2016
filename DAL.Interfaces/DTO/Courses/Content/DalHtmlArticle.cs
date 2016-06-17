namespace DAL.Interfaces.DTO.Courses.Content
{
    public class DalHtmlArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlData { get; set; }
        public int StorageId { get; set; }
        //public virtual IList<Module> Modules { get; set; }
    }
}