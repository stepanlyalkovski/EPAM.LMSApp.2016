using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MvcPL.Models.Module;

namespace MvcPL.Models.Course
{
    public class CourseFullViewModel
    {
        public CourseBaseViewModel CourseBase { get; set; }
        public IEnumerable<ModuleBaseViewModel> Modules { get; set; }
    }
}