using System.Collections.Generic;
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

        public string Description { get; set; }
        public bool IsEditable { get; set; }
        public bool InProgress { get; set; }
        public bool Completed { get; set; }
        public bool Published { get; set; }
        public IList<string> Tags { get; set; }
    }
}