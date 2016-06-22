using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models.CourseModels
{
    public class CourseEditViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [ScaffoldColumn(false)]
        public int ModulesNumber { get; set; }
        [ScaffoldColumn(false)]
        public string Author { get; set; }
        public bool Published { get; set; }
        public string Tags { get; set; }
    }
}
