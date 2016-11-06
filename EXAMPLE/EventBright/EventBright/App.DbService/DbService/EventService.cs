using App.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain;
using App.Util.Exception;
using App.Bo;
using App.DbService.infrastructure;
using AutoMapper;

namespace App.DbService.DbService
{
    public class EventService :BaseService, IEventService
    {
        public Event Create(EventBo events,List<TicketTypeBo> tickerts)
        {
            try
            {
                var item = dba.Events.Add(Mapper.Map<Event>(events));
                foreach (var items in tickerts)
                {
                    items.EventId = item.EventId;
                }
                dba.SaveChanges();
                InsertTickertList(tickerts.Select(x => AutoMapper.Mapper.Map<TicketType>(x)).ToList());
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                var obj = dba.Events.FirstOrDefault(p => p.EventId == key);
                if (obj == null)
                {
                    throw new ItemNotFoundException();
                }
                dba.Events.Remove(obj);
                var tickerts = dba.TicketTypes.Where(p => p.EventId == key);
                dba.TicketTypes.RemoveRange(tickerts);
                dba.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EventCategoryBo> GetEventCategory()
        {
            try
            {
                return dba.EventCategorys.ToList().Select(x => AutoMapper.Mapper.Map<EventCategoryBo>(x)).ToList(); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EventBo> Select(int start,int count)
        {
            try
            {
                 return dba.Events.OrderByDescending(p=>p.EventId).Skip(start).Take(count).ToList().Select(x => AutoMapper.Mapper.Map<EventBo>(x)).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EventBo Select(int key)
        {
            try
            {
                var result = dba.Events.FirstOrDefault(p => p.EventId == key);
                if (result==null)
                {
                    throw new ItemNotFoundException();
                }
                return Mapper.Map <EventBo>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(EventBo item, List<TicketTypeBo> tickerts)
        {
            try
            {
                var obj = dba.Events.FirstOrDefault(p => p.EventId == item.EventId);
                if (obj == null)
                {
                    throw new ItemNotFoundException();
                }
                obj.Image = item.Image;
                obj.LatLon = item.LatLon;
                obj.InsertedUserId = item.InsertedUserId;
                obj.StartDateTime = item.StartDateTime;
                obj.EndDateTime = item.EndDateTime;
                obj.EventCategoryId = item.EventCategoryId;
                obj.Titile = item.Titile;
                obj.Location = item.Location;
                dba.Events.Remove(obj);
                dba.TicketTypes.RemoveRange(dba.TicketTypes.Where(p => p.EventId == item.EventId).ToList());
                dba.SaveChanges();
                InsertTickertList(tickerts.Select(x => AutoMapper.Mapper.Map<TicketType>(x)).ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
         
        public void InsertTickertList(List<TicketType> tickerts)
        {
            try
            {
                dba.TicketTypes.AddRange(tickerts);
                dba.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EventBo Create(EventBo item)
        {
            throw new NotImplementedException();
        }

        public void Update(EventBo item)
        {
            throw new NotImplementedException();
        }

        public List<EventBo> Select()
        {
            throw new NotImplementedException();
        }

        public List<TicketTypeBo> SelectEventTickerts(int eventId)
        {
            try
            {
                return dba.TicketTypes.Where(p=>p.EventId == eventId).ToList().Select(x => AutoMapper.Mapper.Map<TicketTypeBo>(x)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
