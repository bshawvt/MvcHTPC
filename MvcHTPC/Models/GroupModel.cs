using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.Models
{
    public class groups
    {
        public long id { get; set; }
        public long ownersId { get; set; }
        public string name { get; set; } // group name
        public string description { get; set; } // group description

        public DateTime dateOfCreation { get; set; }
    }
}