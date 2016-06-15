using System.Collections.Generic;
using DAL.Interfaces.DTO.Courses.Content;

namespace DAL.Interfaces.Repository
{
    public interface IHtmlArticleRepository
    {
        void Add(int moduleId, DalHtmlArticle article);
        DalHtmlArticle Get(int articleId);
        IEnumerable<DalHtmlArticle> GetModuleArticles(int moduleId);
        void Remove(int articleId);
        void Update(DalHtmlArticle article);
    }
}