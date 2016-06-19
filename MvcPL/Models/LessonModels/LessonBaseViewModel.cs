using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models.LessonModels
{
    public class LessonBaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
    }
}