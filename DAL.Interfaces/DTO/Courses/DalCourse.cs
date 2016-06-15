﻿using System.Collections.Generic;

namespace DAL.Interfaces.DTO.Courses
{
    public class DalCourse : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public int ModulesNumber { get; set; }
        public int UserStorageId { get; set; }
        public IList<string> TagList { get; set; }
        //public virtual IList<DalModule> Modules { get; set; }
        //public virtual IList<DalEnrolment> Enrolment { get; set; }
        ////public virtual DalUserStorage UserStorage { get; set; }
    }
}