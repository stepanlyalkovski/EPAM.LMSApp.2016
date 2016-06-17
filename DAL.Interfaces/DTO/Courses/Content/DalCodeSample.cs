namespace DAL.Interfaces.DTO.Courses.Content
{
    public class DalCodeSample
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Data { get; set; }
        public int StorageId { get; set; }
        //public virtual IList<DalLessonPage> Pages { get; set; }
    }
}