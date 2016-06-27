using MvcPL.Models.ImageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models.LessonPageModels
{
    public class LessonPageViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Title { get; set; }
        [HiddenInput]
        public int LessonId { get; set; }
        [HiddenInput]
        public int ModuleId { get; set; }
        [HiddenInput]
        public int CourseId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

    }
}