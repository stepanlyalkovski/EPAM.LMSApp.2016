using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models.LessonModels
{
    public class LessonBaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public int ModuleId { get; set; }
        [ScaffoldColumn(false)]
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Range(1, 20)]        
        public int PageCount { get; set; }

        public EnrolmentInfo EnrolmentInfo { get; set; }
    }
}