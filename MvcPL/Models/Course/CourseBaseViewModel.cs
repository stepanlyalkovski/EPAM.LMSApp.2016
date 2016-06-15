using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models.Course
{
    public class CourseBaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Chapters")]
        public int ModulesNumber { get; set; }

        public string Tags { get; set; }
    }
}