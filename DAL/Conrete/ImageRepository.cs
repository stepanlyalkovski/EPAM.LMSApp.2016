using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces.DTO.Courses.Content;
using DAL.Interfaces.Repository;
using DAL.Mappers;
using ORM.Courses;
using ORM.Courses.Content;

namespace DAL.Conrete
{
    public class ImageRepository : IImageRepository
    {
        private readonly DbContext _context;

        public ImageRepository(DbContext context)
        {
            _context = context;
        }

        public DalImage Get(int id)
        {
            return _context.Set<Image>().Find(id).ToDalImage();
        }

        public void Add(DalImage image)
        {
            _context.Set<Image>().Add(image.ToOrmImage());
        }

        public void Update(DalImage entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DalImage> GetAll()
        {
            return _context.Set<Image>().Select(im => im.ToDalImage()).ToList();
        }

        public DalImage GetPageImage(int pageId)
        {
            return _context.Set<LessonPage>().Find(pageId).Image.ToDalImage();
        }


        public void Remove(DalImage image)
        {
            var ormImage = _context.Set<Image>().Find(image.Id);
            _context.Set<Image>().Remove(ormImage);
        }
    }
}