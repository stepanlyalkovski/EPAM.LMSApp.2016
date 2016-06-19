using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models.CourseModels
{
    public class CourseBaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Chapters")]
        public int ModulesNumber { get; set; }
        public int UserStorageId { get; set; }
        public string Author { get; set; }
        public bool IsEditable { get; set; }
        public bool Published { get; set; }
        public string Tags { get; set; }
    }
}