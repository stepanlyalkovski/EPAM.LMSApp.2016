using System.Collections.Generic;
using System.Data.Entity;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM;
using ORM.Courses;

namespace DAL.Conrete
{
    public class StorageRepository : IStorageRepository
    {
        private readonly DbContext _context;

        public StorageRepository(DbContext context)
        {
            _context = context;
        }
        public void AddCourse(int storageId, DalCourse course)
        {
            var storage = _context.Set<UserStorage>().Find(storageId);
            var courses = storage.Courses ?? new List<Course>();
            courses.Add(course.ToOrmCourse());
            storage.Courses = courses;
        }
        //public void Add(DalCourse entity)
        //{
        //    _context.Set<Course>().Add(entity.ToOrmCourse());
        //}

        public void GetCreatedCourse(int storageId, DalCourse course)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCourse(int storageId, DalCourse course)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCourse(int storageId, DalCourse course)
        {
            throw new System.NotImplementedException();
        }
    }
}