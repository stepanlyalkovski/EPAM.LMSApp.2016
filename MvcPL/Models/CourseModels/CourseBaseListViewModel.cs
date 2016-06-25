using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models.CourseModels
{
    public class CourseBaseListViewModel
    {
        public IEnumerable<CourseBaseViewModel> Courses { get; set; }
        public PageInfo PageInfo { get; set; }
        public Func<int, string> PageUrl { get; set; }

    }
}