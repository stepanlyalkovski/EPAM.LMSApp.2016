using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO.Courses;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM.Courses;

namespace DAL.Conrete
{
    public class TagRepository : ITagRepository
    {
        private readonly DbContext _context;

        public TagRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<DalTag> Search(string name)
        {
            return _context.Set<Tag>().Where(t => t.TagField == name)
                                      .AsEnumerable()
                                      .Select(t => t.ToDalTag())
                                      .ToList();
        }
    }
}