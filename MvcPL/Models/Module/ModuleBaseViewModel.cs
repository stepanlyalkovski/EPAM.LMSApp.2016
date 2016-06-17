using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models.Module
{
    public class ModuleBaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}