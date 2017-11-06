using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.DTOs
{
    public class ContentDto
    {
        public long id { get; set; }
        public long folderId { get; set; }
        public long ownerId { get; set; }
        public string bodyText { get; set; }
        public string title { get; set; }

        public DateTime dateOfCreation { get; set; }
        public DateTime? lastModification { get; set; }
        public long? modifiedLogId { get; set; }

        public ContentDto()
        {

        }
        public ContentDto(contents c)
        {
            this.id = c.id;
            this.folderId = c.folderId;
            this.ownerId = c.ownerId;
            this.bodyText = c.bodyText;
            this.title = c.title;
            this.dateOfCreation = c.dateOfCreation;
            this.lastModification = c.lastModification;
            this.modifiedLogId = c.modifiedLogId;
        }
    }
}