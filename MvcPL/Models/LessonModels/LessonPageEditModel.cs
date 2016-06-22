using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models.LessonModels
{
    public class LessonPageEditModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [ScaffoldColumn(false)]
        public int LessonId { get; set; }
        [Required]
        public string Text { get; set; }
        public byte[] ImageData { get; set; }
        public string CodeSample { get; set; }
    }
}