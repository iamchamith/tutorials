using App.Bo;
using App.DbService.Interfaces;
using AutoMapper;
using EventBright.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using res = EventBright.Util;
namespace EventBright.Api
{ 
    public class EventsController : BaseController 
    {
        [System.Web.Http.HttpPost]
        public res.JsonResult CreateEvent(EventViewModel item,List<TicketTypeViewModel> tickertTypes) {
            try
            {
                eventService.Create(Mapper.Map<EventBo>(item), tickertTypes.Select(x => AutoMapper.Mapper.Map<TicketTypeBo>(x)).ToList());
                return res.ResponseMessage.Success();
            }
            catch (Exception ex)
            {
                return res.ResponseMessage.Error(ex);
            }
        }
        [System.Web.Http.HttpPost]
        public res.JsonResult UpdateEvent(EventViewModel item, List<TicketTypeViewModel> tickertTypes) {
            try
            {
                eventService.Update(Mapper.Map<EventBo>(item), tickertTypes.Select(x => AutoMapper.Mapper.Map<TicketTypeBo>(x)).ToList());
                return res.ResponseMessage.Success();
            }
            catch (Exception ex)
            {
                return res.ResponseMessage.Error(ex);
            }
        }
        [System.Web.Http.HttpGet]
        public res.JsonResult SelectEvents(int start,int count) {
            try
            {
                return res.ResponseMessage.Success(content: eventService.Select(start, count).Select(x => AutoMapper.Mapper.Map<EventViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return res.ResponseMessage.Error(ex);
            }
        }

        [System.Web.Http.HttpGet]
        public res.JsonResult SelectEvents(int id) {
            try
            {
                return res.ResponseMessage.Success(content: Mapper.Map<EventViewModel>(eventService.Select(id)));
            }
            catch (Exception ex)
            {
                return res.ResponseMessage.Error(ex);
            }
        }

        [System.Web.Http.HttpPost]
        public res.JsonResult SaveImage() {
            return null;
        }
        [System.Web.Http.HttpGet]
        public res.JsonResult GetEventTickerts(int eventId) {

            try
            {
                return res.ResponseMessage.Success(content:eventService.SelectEventTickerts(eventId).Select(x => AutoMapper.Mapper.Map<TicketTypeViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return res.ResponseMessage.Error(ex);
            }
        }
        [System.Web.Http.HttpGet]
        public res.JsonResult GetEventCategories() {

            try
            {
                return res.ResponseMessage.Success(content:eventService.GetEventCategory().Select(x => AutoMapper.Mapper.Map<EventCategoryViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return res.ResponseMessage.Error(ex);
            }
        }
    }
}
