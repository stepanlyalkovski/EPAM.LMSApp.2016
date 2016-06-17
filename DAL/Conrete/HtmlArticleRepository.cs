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

        public void Add(DalHtmlArticle article)
        {
            _context.Set<HtmlArticle>().Add(article.ToOrmHtmlArticle());
        }

        public DalHtmlArticle Get(int articleId)
        {
           return _context.Set<HtmlArticle>().Find(articleId).ToDalHtmlArticle();
        }

        public IEnumerable<DalHtmlArticle> GetModuleArticles(int moduleId)
        {
            return _context.Set<Module>().Find(moduleId).HtmlArticles.Select(a => a.ToDalHtmlArticle()).ToList();
        }

        public IEnumerable<DalHtmlArticle> GetStorageArticles(int storageId)
        {
            return _context.Set<HtmlArticle>().Where(a => a.StorageId == storageId)
                                              .AsEnumerable()
                                              .Select(a => a.ToDalHtmlArticle())
                                              .ToList();
        }

        public void Remove(DalHtmlArticle article)
        {
            var ormArticle = _context.Set<HtmlArticle>().Find(article.Id);
            if (ormArticle != null)
                _context.Set<HtmlArticle>().Remove(ormArticle);
        }

        public void Update(DalHtmlArticle article)
        {
            var ormArticle = _context.Set<HtmlArticle>().Find(article.Id);
            ormArticle.HtmlData = article.HtmlData;
            ormArticle.Title = article.Title;
        }

        public IEnumerable<DalHtmlArticle> GetAll()
        {
           return _context.Set<HtmlArticle>().Select(a => a.ToDalHtmlArticle()).ToList();
        }
    }
}