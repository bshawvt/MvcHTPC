using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.Models
{
    public class notifications
    {
        public long id { get; set; }
        public long? userId { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public DateTime dateOfCreation { get; set; }
    }
}