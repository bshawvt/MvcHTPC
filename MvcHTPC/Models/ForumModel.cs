using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MvcHTPC.Models.DbModels.DbStaticEnums;

namespace MvcHTPC.Models
{
    /*
     * 
     *  Foreign keys:
     *      groupIds: which groups 
     */
    public class forums
    {
        public long id { get; set; }
        public string groupIds { get; set; }
        public string title { get; set; } // forums hold folders
        public string description { get; set; }
        public HiddenState? hidden { get; set; }
        public bool? locked { get; set; }

        public DateTime dateOfCreation { get; set; }

    }
}