using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models.ImageModels
{
    public class ImageListViewModel
    {
        public IEnumerable<ImageViewModel> Images { get; set; }

        public bool AttachMode { get; set; } // to attach storage images to Lesson Page
        public PathContextModel Path { get; set; }
    }
}