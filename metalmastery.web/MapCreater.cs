﻿using AutoMapper;
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
            ViceVersa<Article, ArticleModel>();
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