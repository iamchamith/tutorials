using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Bo;
using App.Domain;
using AuthorizationAndAuthontication.Models.User;
using AutoMapper;
using RoleAccess = App.Domain.RoleAccess;

namespace AuthorizationAndAuthontication.App_Start
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig()
        {
            Mapper.CreateMap<UserViewModel, UserBo>();
            Mapper.CreateMap<UserBo, UserViewModel>();

            Mapper.CreateMap<Users, UserBo>();
            Mapper.CreateMap<UserBo, Users>();

            Mapper.CreateMap<Users, GCUserSession>();
            Mapper.CreateMap<GCUserSession, Users>();

            Mapper.CreateMap<GCUserSession, UserSession>();
            Mapper.CreateMap<UserSession, GCUserSession>();

            Mapper.CreateMap<RoleAccessBo, RoleAccess>();
            Mapper.CreateMap<RoleAccess, RoleAccessBo>();

            Mapper.CreateMap<EmailConfigBo, EmailConfig>();
            Mapper.CreateMap<EmailConfig, EmailConfigBo>();

            Mapper.CreateMap<Role, RoleBo>();
            Mapper.CreateMap<RoleBo, Role>();
        }
    }
}