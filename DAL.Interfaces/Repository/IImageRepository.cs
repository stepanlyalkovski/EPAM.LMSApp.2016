using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IImageRepository : IRepository<DalImage>
    {
        DalImage GetPageImage(int pageId);
        DalImage Get(string path);
        IEnumerable<DalImage> GetStorageImages(int storageId);
    }
}