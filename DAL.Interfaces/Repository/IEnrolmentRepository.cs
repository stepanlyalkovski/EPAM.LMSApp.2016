using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses;

namespace DAL.Interfaces.Repository
{
    public interface IEnrolmentRepository : IRepository<DalEnrolment>
    {
        DalEnrolment Get(int profileId, int courseId);
        void AttachProgress(DalEnrolment enrolment);
        IEnumerable<DalEnrolment> GetStudentEnrolments(int profileId);
    }
}