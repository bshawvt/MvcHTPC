using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.Models
{
    /*
     * 
     *  Foreign keys:
     *      folderId: which folder this content is located
     *      userId: who created this content
     *
     */
    public class contents
    {
        public long id { get; set; }
        public long folderId { get; set; }
        public long ownerId { get; set; }
        public string bodyText { get; set; }
        public string title { get; set; }

        public DateTime dateOfCreation { get; set; }
        public DateTime? lastModification { get; set; }

        public long? modifiedLogId { get; set; }
    }
}