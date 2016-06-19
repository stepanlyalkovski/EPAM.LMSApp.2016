using System.Collections.Generic;
using MvcPL.Models.ArticleModels;
using MvcPL.Models.LessonModels;
using MvcPL.Models.QuizModels;

namespace MvcPL.Models.ModuleModels
{
    public class ModuleContentViewModel
    {
        public ModuleBaseViewModel BaseInfo { get; set; }
        public QuizBaseViewModel Quiz { get; set; }
        public LessonBaseViewModel Lesson { get; set; }
        public IEnumerable<ArticleBaseViewModel> Articles { get; set; }
    }
}