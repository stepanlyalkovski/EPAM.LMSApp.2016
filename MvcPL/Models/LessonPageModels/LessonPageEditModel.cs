using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models.LessonModels
{
    public class LessonPageEditModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [HiddenInput]
        public int LessonId { get; set; }
        [HiddenInput]
        public int ModuleId { get; set; }
        [HiddenInput]
        public int CourseId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public ImageViewModel Image { get; set; }
        
        public string CodeSample { get; set; }
    }
}