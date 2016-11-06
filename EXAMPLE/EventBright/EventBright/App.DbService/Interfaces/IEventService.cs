using App.Bo;
using App.DbService.infrastructure;
using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbService.Interfaces
{
    public interface IEventService: infrastructure.IRepositoty<EventBo,int>
    {
        List<EventCategoryBo> GetEventCategory();
        List<EventBo> Select(int start, int count);
        void InsertTickertList(List<TicketType> tickerts);
        List<TicketTypeBo> SelectEventTickerts(int eventId);
    }
}
