using MvcHTPC.DTOs;
using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MvcHTPC.Services
{
    public class ForumService
    {
        MvcHTPCContext db = new MvcHTPCContext();
        public List<FolderDto> GetForumFolderDtosByDate(long id)
        {
            List<FolderDto> dtos = new List<FolderDto>();
            var d = from i in db.tblFolders
                    where i.forumId == id
                    select new FolderDto
                    {
                        description = i.description,
                        dateOfCreation = i.dateOfCreation,
                        forumId = i.forumId,
                        groupIds = i.groupIds,
                        hidden = i.hidden,
                        lastModified = i.lastModified,
                        location = i.location,
                        locked = i.locked,
                        ownersId = i.ownersId,
                        modifiedLogId = i.modifiedLogId,
                        title = i.title,
                        iconText = i.iconText
                    };
            dtos = d.ToList();
            Debug.WriteLine("d: {0}", d.Count());
            return dtos;
        }
    }
}