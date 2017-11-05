using MvcHTPC.DTOs;
using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.Services
{
    public class CommunityService
    {
        MvcHTPCContext db = new MvcHTPCContext();
        public List<ForumDto> GetForumDtos()
        {
            List<ForumDto> dtos = new List<ForumDto>();
            foreach(var i in db.tblForums)
            {
                dtos.Add(new ForumDto(i));
            }
            return dtos;
        }
        public ContentDto GetContentDtoByLastDate()
        {
            var item = from i in db.tblContents.OrderByDescending(x => x.dateOfCreation)
                       select i;
            return new ContentDto(item.FirstOrDefault());
        }
    }
}