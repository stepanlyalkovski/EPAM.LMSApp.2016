using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Models
{
    public class ImageViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        [HiddenInput]
        public int StorageId { get; set; }
    }
}