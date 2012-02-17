﻿using AutoMapper;
using MetalMastery.Admin.Models;
using MetalMastery.Core.Domain;

namespace MetalMastery.Admin
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
    }
}