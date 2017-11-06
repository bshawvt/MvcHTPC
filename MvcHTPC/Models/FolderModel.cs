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
     *      forumId: which forum this folder is attached to
     *      groupIds: groups this folder belong to. delimiter: "id|id2"
     */
    public class folders
    {
        public long ownersId { get; set; }
        public string location { get; set; }

        public long id { get; set; }
        public long? forumId { get; set; }
        public string groupIds { get; set; }
        //public string locationId { get; set; } // location url gibberish, eg, /folder/Tx3325cce94tid44tfiao/
        public string title { get; set; } // folder title
        public string description { get; set; }
        public bool? locked { get; set; } // can items be modified or added to this folder
        public HiddenState? hidden { get; set; } // can this folder be viewed

        public DateTime dateOfCreation { get; set; }
        public DateTime? lastModified { get; set; }

        public long? modifiedLogId { get; set; }

        public string iconText { get; set; }



    }
}