using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Bo;
using App.Domain;
using AutoMapper;

namespace AuthorizationAndAuthontication.App_Start
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig()
        {
            Mapper.CreateMap<User, UserBo>();
            Mapper.CreateMap<UserBo, User>();

            Mapper.CreateMap<User, GCUserSession>();
            Mapper.CreateMap<GCUserSession, User>();

            Mapper.CreateMap<RoleAccessBo, RoleAccess>();
            Mapper.CreateMap<RoleAccess, RoleAccessBo>();
        }
    }
}