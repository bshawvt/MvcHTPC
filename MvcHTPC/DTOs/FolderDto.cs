using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MvcHTPC.Models.DbModels.DbStaticEnums;

namespace MvcHTPC.DTOs
{
    public class FolderDto
    {
        public long id { get; set; }
        public long? forumId { get; set; }
        public long ownersId { get; set; }
        public string groupIds { get; set; }
        public string location { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool? locked { get; set; }
        public HiddenState? hidden { get; set; }
        public DateTime dateOfCreation { get; set; }
        public DateTime? lastModified { get; set; }
        public long? modifiedLogId { get; set; }
        public string iconText { get; set; }

        public FolderDto()
        {

        }
        public FolderDto(folders f)
        {
            this.dateOfCreation = f.dateOfCreation;
            this.forumId = f.forumId;
            this.groupIds = f.groupIds;
            this.hidden = f.hidden;
            this.id = f.id;
            this.lastModified = f.lastModified;
            this.location = f.location;
            this.locked = f.locked;
            this.ownersId = f.ownersId;
            this.title = f.title;
            this.description = f.description;
            this.modifiedLogId = f.modifiedLogId;
            this.iconText = f.iconText;

        }

    }
}