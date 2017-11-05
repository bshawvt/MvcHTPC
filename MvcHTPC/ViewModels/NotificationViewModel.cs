using MvcHTPC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.ViewModels
{
    public class NotificationViewModel
    {
        public List<NotificationDto> notificationDtos { get; set; }
        
        public NotificationViewModel()
        {
            this.notificationDtos = new List<NotificationDto>();
        }
    }
}