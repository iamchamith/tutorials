using App.Bo;
using App.Domain;
using AutoMapper;
using EventBright.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBright.App_Start
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig() {
            Mapper.CreateMap<Event, EventBo>();
            Mapper.CreateMap<EventBo, Event>();

            Mapper.CreateMap<EventBo, EventViewModel>();
            Mapper.CreateMap<EventViewModel, EventBo >();

            Mapper.CreateMap<TicketType, TicketTypeBo>();
            Mapper.CreateMap<TicketTypeBo, TicketType>();

            Mapper.CreateMap<TicketTypeViewModel, TicketTypeBo>();
            Mapper.CreateMap<TicketTypeBo, TicketTypeViewModel>();

            Mapper.CreateMap<EventCategoryViewModel, EventCategoryBo>();
            Mapper.CreateMap<EventCategoryBo, EventCategoryViewModel>();

            Mapper.CreateMap<EventCategory, EventCategoryBo>();
            Mapper.CreateMap<EventCategoryBo, EventCategory>();
        }
    }
}