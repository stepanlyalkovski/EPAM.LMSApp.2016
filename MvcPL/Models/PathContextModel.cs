using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class PathContextModel
    {
        public int CourseId { get; set; }
        public int ModuleId { get; set; }
        public int LessonId { get; set; }
        public int LessonPageId { get; set; }
        public int Page { get; set; }
    }
}