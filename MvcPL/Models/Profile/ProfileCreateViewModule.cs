using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models
{
    public class ProfileCreateViewModule
    {
        [ScaffoldColumn(false)]
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}