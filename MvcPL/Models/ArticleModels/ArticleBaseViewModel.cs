using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models.ArticleModels
{
    public class ArticleBaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string HtmlData { get; set; }
        [ScaffoldColumn(false)]
        public int StorageId { get; set; }
        [HiddenInput]
        public int CourseId { get; set; }
        [HiddenInput]
        public int ModuleId { get; set; }
    }
}