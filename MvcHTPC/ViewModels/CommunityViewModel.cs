using MvcHTPC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.ViewModels
{
    public class CommunityViewModel
    {
        public List<ForumDto> forumDtos { get; set; }
        public List<FolderDto> folderDtos { get; set; }
        public ContentDto contentDto { get; set; }
        
        public CommunityViewModel()
        {
            this.forumDtos = new List<ForumDto>();
            this.folderDtos = new List<FolderDto>();
        }

    }

}