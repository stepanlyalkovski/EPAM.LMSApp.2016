using System.Collections.Generic;
using BLL.Interfaces.Entities.Courses.Content;

namespace BLL.Interfaces.Services
{
    public interface IContentService<TEntity>
    {
        void AddEntity(TEntity entity);
        void RemoveImage(TEntity entity);
        TEntity GetEntity(int entityId);
        TEntity GetLessonPageEntity(int lessonPageId);
        IEnumerable<ImageEntity> GetStorageEntities(int storageId);
    }
}