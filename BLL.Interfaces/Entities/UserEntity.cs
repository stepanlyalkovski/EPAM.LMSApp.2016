using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime DateAdded { get; set; }
        public int RoleId { get; set; }
        public IList<string> Tags { get; set; }
    }
}
