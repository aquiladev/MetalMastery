using System;
using AutoMapper;
using MetalMastery.Core.Domain;
using MetalMastery.Web.Areas.Admin.Models;
using MetalMastery.Web.Framework.AutoMapper;
using MetalMastery.Web.Models;

namespace MetalMastery.Web
{
    public static class MapCreater
    {
        public static void Init()
        {
            Mapper.CreateMap<string, byte[]>().ConvertUsing(new StrToBytesConverter());
            Mapper.CreateMap<string, DateTime>().ConvertUsing(new StrToDateConverter());
            Mapper.CreateMap<DateTime, string>().ConvertUsing(new DateToStrConverter());

            ViceVersa<User, UserModel>();

            Mapper.CreateMap<User, LogOnModel>()
                .ForMember(dest => dest.RememberMe, opt => opt.Ignore());
            Mapper.CreateMap<LogOnModel, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdmin, opt => opt.Ignore())
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.Articles, opt => opt.Ignore());

            Mapper.CreateMap<User, RegistrateModel>()
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore());
            Mapper.CreateMap<RegistrateModel, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsAdmin, opt => opt.Ignore())
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.Articles, opt => opt.Ignore());

            Mapper.CreateMap<Article, ArticleModel>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(x => x.Owner.Email));
            Mapper.CreateMap<ArticleModel, Article>()
                .ForMember(dest => dest.Owner, opt => opt.Ignore());

            ViceVersa<Format, FormatModel>();
            ViceVersa<Material, MaterialModel>();
            ViceVersa<Tag, TagModel>();
            ViceVersa<Thing, ThingModel>();
            Mapper.AssertConfigurationIsValid();
        }

        private static void ViceVersa<T1, T2>()
        {
            Mapper.CreateMap<T1, T2>();
            Mapper.CreateMap<T2, T1>();
        }
    }
}