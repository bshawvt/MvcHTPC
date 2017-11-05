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
    *      groupIds: groups this user is a member of. delimiter |, eg, "id1|id2|id6"=
    */

    public class users
    {
        public long id { get; set; } // unique identifier
        public AccessLevel accessLevel { get; set; } // onsite options
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string email { get; set; }
        public string groupIds { get; set; }

        public DateTime dateOfCreation { get; set; }
    }
}