using System.Collections.Generic;
using MvcPL.Models.ModuleModels;

namespace MvcPL.Models.CourseModels
{
    public class CourseFullViewModel
    {
        public CourseFullViewModel(CourseBaseViewModel courseBase, IEnumerable<ModuleBaseViewModel> modules)
        {
            CourseBase = courseBase;
            Modules = modules;
        }

        public CourseBaseViewModel CourseBase { get; set; }
        public IEnumerable<ModuleBaseViewModel> Modules { get; set; }
        public EnrolmentInfo EnrolmentInfo { get; set; }
    }
}