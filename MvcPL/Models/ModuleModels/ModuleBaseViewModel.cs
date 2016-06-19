using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models.ModuleModels
{
    public class ModuleBaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}