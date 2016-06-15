﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models.Course
{
    public class CourseCreateViewModel
    {
        [Required(ErrorMessage = "Fill title")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter number of chapters")]
        [Display(Name = "Chapters", Description = "Number of modules that is going to be created")]
        public int ModulesNumber { get; set; }
        [Required(ErrorMessage = "write at least one tag")]
        public string Tags { get; set; }
        //public bool WeeklyFormat { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime? StartDate { get; set; }
    }
}