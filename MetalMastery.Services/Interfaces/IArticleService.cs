using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services.Interfaces
{
    public interface IArticleService : IBaseEntityService<Article>
    {
        IPagedList<Article> GetPublishedArticles(int pageIndex, int pageSize);
    }
}
