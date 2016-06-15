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
    public class HtmlArticleRepository : IHtmlArticleRepository
    {
        private readonly DbContext _context;

        public HtmlArticleRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(int moduleId, DalHtmlArticle article)
        {
            var ormModule = _context.Set<Module>().Find(moduleId);
            var articles = ormModule.HtmlArticles ?? new List<HtmlArticle>();
            articles.Add(article.ToOrmHtmlArticle());
            ormModule.HtmlArticles = articles;
        }

        public DalHtmlArticle Get(int articleId)
        {
           return _context.Set<HtmlArticle>().Find(articleId).ToDalHtmlArticle();
        }

        public IEnumerable<DalHtmlArticle> GetModuleArticles(int moduleId)
        {
            return _context.Set<Module>().Find(moduleId).HtmlArticles.Select(a => a.ToDalHtmlArticle()).ToList();
        }

        public void Remove(int articleId)
        {
            var article = _context.Set<HtmlArticle>().Find(articleId);
            if (article != null)
                _context.Set<HtmlArticle>().Remove(article);
        }

        public void Update(DalHtmlArticle article)
        {
            var ormArticle = _context.Set<HtmlArticle>().Find(article.Id);
            ormArticle.HtmlData = article.HtmlData;
            ormArticle.Title = article.Title;
        }
    }
}