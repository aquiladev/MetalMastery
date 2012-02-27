using AutoMapper;
using MetalMastery.Core.Domain;
using MetalMastery.Web.Areas.Admin.Models;
using MetalMastery.Web.Models;

namespace MetalMastery.Web
{
    public static class MapCreater
    {
        public static void Init()
        {
            ViceVersa<User, UserModel>();
            ViceVersa<User, LogOnModel>();
            ViceVersa<User, RegistrateModel>();
            Mapper.CreateMap<Article, ArticleModel>()
                .ForMember(x => x.Owner, a => a.Ignore());
            Mapper.CreateMap<ArticleModel, Article>();
            ViceVersa<Format, FormatModel>();
            ViceVersa<Material, MaterialModel>();
            ViceVersa<Tag, TagModel>();
        }

        private static void ViceVersa<T1, T2>()
        {
            Mapper.CreateMap<T1, T2>();
            Mapper.CreateMap<T2, T1>();
        }
    }
}