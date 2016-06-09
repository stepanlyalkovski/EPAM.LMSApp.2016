using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM
{
    public class Profile
    {
        [Key]
        [ForeignKey("User")]
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public virtual User User { get; set; }

        public virtual IList<Enrolment> Enrolment { get; set; }
    }
}