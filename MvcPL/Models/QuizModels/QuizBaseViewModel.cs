using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models.QuizModels
{
    public class QuizBaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ScaffoldColumn(false)]
        public string DataFilePath { get; set; }
        [ScaffoldColumn(false)]
        public int StorageId { get; set; }

        public EnrolmentInfo EnrolmentInfo { get; set; }
    }
}