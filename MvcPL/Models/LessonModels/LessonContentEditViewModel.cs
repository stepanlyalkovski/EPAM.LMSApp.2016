using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models.LessonModels
{
    public class LessonContentEditViewModel
    {
        public LessonBaseViewModel BaseInfo { get; set; }
        public LessonPageEditModel Page {get; set;}
        public PageInfo PageInfo { get; set; }

    }
}