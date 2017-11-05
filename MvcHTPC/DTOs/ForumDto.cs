using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MvcHTPC.Models.DbModels.DbStaticEnums;

namespace MvcHTPC.DTOs
{
    public class ForumDto
    {
        public long id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string groupIds { get; set; }
        public HiddenState? hidden { get; set; }
        public bool? locked { get; set; }
        public DateTime dateOfCreation { get; set; }

        public ForumDto()
        {

        }
        public ForumDto(forums f)
        {
            this.id = f.id;
            this.title = f.title;
            this.description = f.description;
            this.groupIds = f.groupIds;
            this.hidden = f.hidden;
            this.locked = f.locked;
            this.dateOfCreation = f.dateOfCreation;
        }

    }
}