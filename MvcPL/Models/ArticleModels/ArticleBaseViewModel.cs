using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models.ArticleModels
{
    public class ArticleBaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlData { get; set; }
        [ScaffoldColumn(false)]
        public int StorageId { get; set; }
    }
}