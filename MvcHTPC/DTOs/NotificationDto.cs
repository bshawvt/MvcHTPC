using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.DTOs
{
    public class NotificationDto
    {
        public long id { get; set; }
        public long? userId { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public DateTime dateOfCreation { get; set; }

        public NotificationDto(notifications n)
        {
            this.id = n.id;
            this.userId = n.userId;
            this.title = n.title;
            this.message = n.message;
            this.dateOfCreation = n.dateOfCreation;

        }

    }


}