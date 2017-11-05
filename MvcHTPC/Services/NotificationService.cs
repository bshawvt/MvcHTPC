using MvcHTPC.DTOs;
using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.Services
{
    public class NotificationService
    {
        private MvcHTPCContext db = new MvcHTPCContext();
        public NotificationService()
        {

        }

        public List<NotificationDto> GetLastMinutesNotifications()
        {
            
            List<NotificationDto> dtos = new List<NotificationDto>();
            foreach (var i in db.tblNotifications.OrderByDescending(x=>x.dateOfCreation))
            {
                if (i.dateOfCreation.AddSeconds(4) > DateTime.Now)
                    dtos.Add(new NotificationDto(i));
            }
            return dtos;
        }
    }
}