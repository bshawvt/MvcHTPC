using MvcHTPC.DTOs;
using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.Services
{
    public class ContentService
    {
        private MvcHTPCContext db = new MvcHTPCContext();
        public ContentService()
        {

        }

        public List<ContentDto> GetAllContentByFolderId(long id)
        {
            var r = db.tblContents.Where(x => x.folderId == id);
            List<ContentDto> l = new List<ContentDto>();
            foreach (var rr in r)
            {
                l.Add(new ContentDto(rr));
            }
            return l;
        }
    }
}