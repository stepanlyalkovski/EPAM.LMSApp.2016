using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IImageRepository : IRepository<DalImage>
    {
        DalImage GetPageImage(int pageId);
        IEnumerable<DalImage> GetStorageImages(int storageId);
    }
}