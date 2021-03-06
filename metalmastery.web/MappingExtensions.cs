﻿using AutoMapper;
using MetalMastery.Core.Domain;
using MetalMastery.Web.Areas.Admin.Models;
using MetalMastery.Web.Models;

namespace MetalMastery.Web
{
    public static class MappingExtensions
    {
        #region User

        public static UserModel ToModel(this User entity)
        {
            return Mapper.Map<User, UserModel>(entity);
        }

        public static User ToEntity(this UserModel model)
        {
            return Mapper.Map<UserModel, User>(model);
        }

        public static User ToEntity(this UserModel model, User destination)
        {
            return Mapper.Map(model, destination);
        }

        #endregion

        #region SignUpModel

        public static User ToEntity(this SignUpModel model)
        {
            return Mapper.Map<SignUpModel, User>(model);
        }

        #endregion

        #region Article

        public static ArticleModel ToModel(this Article entity)
        {
            return Mapper.Map<Article, ArticleModel>(entity);
        }

        public static Article ToEntity(this ArticleModel model)
        {
            return Mapper.Map<ArticleModel, Article>(model);
        }

        public static Article ToEntity(this ArticleModel model, Article destination)
        {
            return Mapper.Map(model, destination);
        }

        #endregion

        #region Format

        public static FormatModel ToModel(this Format entity)
        {
            return Mapper.Map<Format, FormatModel>(entity);
        }

        public static Format ToEntity(this FormatModel model)
        {
            return Mapper.Map<FormatModel, Format>(model);
        }

        public static Format ToEntity(this FormatModel model, Format destination)
        {
            return Mapper.Map(model, destination);
        }

        #endregion

        #region Material

        public static MaterialModel ToModel(this Material entity)
        {
            return Mapper.Map<Material, MaterialModel>(entity);
        }

        public static Material ToEntity(this MaterialModel model)
        {
            return Mapper.Map<MaterialModel, Material>(model);
        }

        public static Material ToEntity(this MaterialModel model, Material destination)
        {
            return Mapper.Map(model, destination);
        }

        #endregion

        #region Tag

        public static TagModel ToModel(this Tag entity)
        {
            return Mapper.Map<Tag, TagModel>(entity);
        }

        public static Tag ToEntity(this TagModel model)
        {
            return Mapper.Map<TagModel, Tag>(model);
        }

        public static Tag ToEntity(this TagModel model, Tag destination)
        {
            return Mapper.Map(model, destination);
        }

        #endregion

        #region Thing

        public static ThingModel ToModel(this Thing entity)
        {
            return Mapper.Map<Thing, ThingModel>(entity);
        }

        public static Thing ToEntity(this ThingModel model)
        {
            return Mapper.Map<ThingModel, Thing>(model);
        }

        public static Thing ToEntity(this ThingModel model, Thing destination)
        {
            return Mapper.Map(model, destination);
        }

        #endregion
    }
}