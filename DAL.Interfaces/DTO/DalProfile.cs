using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.DTO
{
    public class DalProfile
    {
        //public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public DalUser User { get; set; }

        public IList<DalEnrolment> Enrolment { get; set; }
    }
}