using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;
using ORM.Courses;

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

        public DalEnrolment Get(int profileId, int courseId)
        {
            return _context.Set<Enrolment>().FirstOrDefault(e => e.ProfileId == profileId 
                                                              && e.CourseId == courseId)
                                            .ToDalEnrolment();
        }

        public void AttachProgress(DalEnrolment enrolment)
        {
            var localEnrolment = _context.Set<Enrolment>().Local.First(e => e.CourseId == enrolment.CourseId);
            var course = _context.Set<Course>().Find(enrolment.CourseId);
            localEnrolment.Progress = new List<CourseProgress>();
            foreach (var module in course.Modules)
            {
                localEnrolment.Progress.Add(new CourseProgress
                {
                    Module = module
                });
            }
            
        }

        public IEnumerable<DalEnrolment> GetStudentEnrolments(int profileId)
        {
            return _context.Set<Profile>().Find(profileId).Enrolment
                                                          .AsEnumerable()
                                                          .Select(e => e.ToDalEnrolment());
        }
    }
}