namespace MvcPL.Models.LessonModels
{
    public class LessonContentViewModel
    {
        public LessonBaseViewModel BaseInfo { get; set; }
        public LessonPageEditModel Page { get; set; }
        public PageInfo PageInfo { get; set; }
        public EnrolmentInfo EnrolmentInfo { get; set; }
    }
}