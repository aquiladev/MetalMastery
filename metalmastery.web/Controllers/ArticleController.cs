using System.Linq;
using System.Web.Mvc;
using MetalMastery.Core.Mvc;
using MetalMastery.Services;

namespace MetalMastery.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public JsonResult GetArticles(int pageIndex = 0, int pageSize = 10)
        {
            return new MmJsonResult(_articleService.GetAllArticles(pageIndex, pageSize)
                                        .Select(x => x.ToModel())
                                        .ToList());
        }
    }
}