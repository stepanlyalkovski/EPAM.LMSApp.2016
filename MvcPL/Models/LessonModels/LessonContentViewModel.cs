using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models.LessonModels
{
    public class LessonContentViewModel
    {
        public LessonBaseViewModel BaseInfo { get; set; }
        public  IList<LessonPageEditModel> Pages {get; set;}
    }
}