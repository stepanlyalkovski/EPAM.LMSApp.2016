﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }

        //public DalRole Role { get; set; }
        public virtual DalProfile Profile { get; set; }
        public virtual DalUserStorage UserStorage { get; set; }
    }
}
