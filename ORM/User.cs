using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("Role")]
        [Required]
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual UserStorage UserStorage { get; set; }
    }
}
