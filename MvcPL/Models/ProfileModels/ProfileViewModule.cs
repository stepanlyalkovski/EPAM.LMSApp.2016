using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcPL.Models.ProfileModels
{
    public class ProfileViewModule
    {
        [HiddenInput(DisplayValue = false)]
        public int ProfileId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}