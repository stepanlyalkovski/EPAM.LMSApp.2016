using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models.LessonModels
{
    public class LessonBaseEditModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [HiddenInput]
        public int ModuleId { get; set; }
        [HiddenInput]
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}