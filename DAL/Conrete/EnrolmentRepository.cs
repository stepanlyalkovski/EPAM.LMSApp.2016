using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;

namespace DAL.Conrete
{
    public class EnrolmentRepository : IEnrolmentRepository
    {
        private readonly DbContext _context;

        public EnrolmentRepository(DbContext context)
        {
            _context = context;
        }

        public DalEnrolment Get(int id)
        {
            return _context.Set<Enrolment>().Find(id).ToDalEnrolment();
        }

        public void Add(DalEnrolment entity)
        {
            _context.Set<Enrolment>().Add(entity.ToOrmEnrolment());
        }

        public void Remove(DalEnrolment entity)
        {
            var ormEnrolment = _context.Set<Enrolment>().Find(entity.Id);
            _context.Set<Enrolment>().Remove(ormEnrolment);
        }

        public void Update(DalEnrolment entity)
        {
            var ormEnrolment = _context.Set<Enrolment>().Find(entity.Id);
            ormEnrolment.CourseCompleted = entity.CourseCompleted;
        }

        public IEnumerable<DalEnrolment> GetAll()
        {
            return _context.Set<Enrolment>().Select(en => en.ToDalEnrolment()).ToList();
        }
    }
}