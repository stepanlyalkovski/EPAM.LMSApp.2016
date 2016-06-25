using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Services;
using MvcPL.Infrastructure.Mappers;
using MvcPL.Models.ArticleModels;

namespace MvcPL.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;
        private readonly ICourseService _courseService;
        private readonly IModuleService _moduleService;

        public ArticleController(IStorageService storageService, IUserService userService, ICourseService courseService, IModuleService moduleService)
        {
            _storageService = storageService;
            _userService = userService;
            _courseService = courseService;
            _moduleService = moduleService;
        }

        // GET: Article
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int courseId, int moduleId, int articleId)
        {
            var article = _storageService.GetHtmlArticle(articleId).ToArticleBaseViewModel();
            article.ModuleId = moduleId;
            article.CourseId = courseId;
            return View(article);
        }

        public ActionResult Create(int courseId, int moduleId)
        {
            var preInitialized = new ArticleBaseViewModel {CourseId = courseId, ModuleId = moduleId};
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticleBaseViewModel article)
        {
             int userId = _userService.GetUserEntity(User.Identity.Name).Id;
             article.StorageId = userId;
            _storageService.AddHtmlArticle(article.ToHtmlArticleEntity());
           
            var articles = _storageService.GetHtmlArticles(userId);
            var articleEntity = articles?.FirstOrDefault(a => a.Title == article.Title && a.HtmlData == article.HtmlData);
            _moduleService.AttachArticle(articleEntity, article.ModuleId);

            return RedirectToAction("Details", "Module", new { moduleId = article.ModuleId, courseId = article.CourseId });
        }

        [HttpGet]
        public ActionResult Delete(int articleId, int courseId, int moduleId)
        {
            var article = _storageService.GetHtmlArticle(articleId).ToArticleBaseViewModel();
            article.ModuleId = moduleId;
            article.CourseId = courseId;
            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ArticleBaseViewModel article)
        {
            _moduleService.DetachArticle(article.ToHtmlArticleEntity(), article.ModuleId);

            return RedirectToAction("Details", "Module", new { moduleId = article.ModuleId, courseId = article.CourseId });
        }

        public ActionResult Edit(int courseId, int moduleId, int articleId)
        {
            var article = _storageService.GetHtmlArticle(articleId).ToArticleBaseViewModel();
            article.ModuleId = moduleId;
            article.CourseId = courseId;
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(ArticleBaseViewModel article)
        {
            _storageService.UpdateHtmlArticle(article.ToHtmlArticleEntity());
            return RedirectToAction("Details", "Module", new { moduleId = article.ModuleId, courseId = article.CourseId });
        }
    }
}