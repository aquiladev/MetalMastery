using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Admin.App_LocalResources;
using MetalMastery.Admin.Models;
using MetalMastery.Services;
using MetalMastery.Admin.Filters;

namespace MetalMastery.Admin.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;
        
        public ArticleController(IArticleService articleService,
            IUserService userService)
        {
            _articleService = articleService;
            _userService = userService;
        }

        public ViewResult Index()
        {
            return View(_articleService.GetAllArticles(0, 10)
                .Select(x => x.ToModel())
                .ToList());
        }

        public ViewResult Details(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            return View(_articleService.GetArticleById(id).ToModel());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [UserNameFilter]
        public ActionResult Create([Bind(Exclude = "Id")]ArticleModel article, string username)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }

            var user = _userService.GetUserByEmail(username);

            if (user == null)
            {
                ViewBag.Error = MmAdminResources.UserDidntFound;
                return View(article);
            }

            article.CreateDate = DateTime.UtcNow;
            article.Owner = user;

            _articleService.InsertArticle(article.ToEntity());

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                ViewBag.Error = MmAdminResources.IdEmptyError;
                return View();
            }

            var article = _articleService.GetArticleById(id).ToModel();

            if (article == null)
            {
                ViewBag.Error = MmAdminResources.UserDidntFound;
                return View();
            }

            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(ArticleModel article)
        {
            if (!ModelState.IsValid)
            {
                return View(_articleService.GetArticleById(article.Id).ToModel());
            }

            _articleService.UpdateArticle(article.ToEntity());

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var article = _articleService.GetArticleById(id);

            if (article == null)
            {
                ViewBag.Error = MmAdminResources.ArticleDidntFound;
                return View();
            }

            return View(article.ToModel());
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id.Equals(default(Guid)))
                throw new ArgumentNullException("id");

            var article = _articleService.GetArticleById(id);

            if (article == null)
            {
                ViewBag.Error = MmAdminResources.ArticleDidntFound;
                return View();
            }

            _articleService.DeleteArticle(article);

            return RedirectToAction("Index");
        }
    }
}