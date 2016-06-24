using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcPL.Models.ModuleModels
{
    public class ModuleBaseViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [ScaffoldColumn(false)]
        public bool IsEditable { get; set; }
        [ScaffoldColumn(false)]
        public int CourseId { get; set; }
    }
}