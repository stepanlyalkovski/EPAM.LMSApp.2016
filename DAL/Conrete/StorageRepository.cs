using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO;
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

        public DalUserStorage Get(int id)
        {
            return _context.Set<UserStorage>().Find(id).ToDalUserStorage();
        }

        public void Add(DalUserStorage entity)
        {
            _context.Set<UserStorage>().Add(entity.ToOrmUserStorage());
        }

        public void Remove(DalUserStorage entity)
        {
            var ormStorage = _context.Set<UserStorage>().Find(entity.UserId);
            _context.Set<UserStorage>().Remove(ormStorage);
        }

        public void Update(DalUserStorage entity)
        {
            var ormStorage = _context.Set<UserStorage>().Find(entity.UserId);
            ormStorage.StorageName = entity.StorageName;
        }

        public IEnumerable<DalUserStorage> GetAll()
        {
            return _context.Set<UserStorage>().Select(s => s.ToDalUserStorage());
        }
    }
}