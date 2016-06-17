using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IHtmlArticleRepository : IRepository<DalHtmlArticle>
    {
        IEnumerable<DalHtmlArticle> GetModuleArticles(int moduleId);
        IEnumerable<DalHtmlArticle> GetStorageArticles(int storageId);
    }
}