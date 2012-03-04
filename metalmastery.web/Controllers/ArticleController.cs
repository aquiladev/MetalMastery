using System;
using System.Linq;
using System.Web.Mvc;
using MetalMastery.Core.Mvc;
using MetalMastery.Services;
using MetalMastery.Web.Framework.Filters;

namespace MetalMastery.Web.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [CheckModelFilter]
        public JsonResult GetArticles(int pageIndex = 0, int pageSize = 10)
        {
            return new MmJsonResult(_articleService.GetAllArticles(pageIndex, pageSize)
                                        .Select(x => x.ToModel())
                                        .ToList());
        }

        [CheckModelFilter]
        public JsonResult Details(Guid id)
        {
            return new MmJsonResult(_articleService.GetArticleById(id).ToModel());
        }
    }
}