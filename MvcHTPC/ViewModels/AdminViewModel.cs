using MvcHTPC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MvcHTPC.Models.DbModels.DbStaticEnums;

namespace MvcHTPC.ViewModels
{
    public class AdminViewModel
    {
        public List<UserDto> userDtos { get; set; }
        public List<FolderDto> folderDtos { get; set; }
        public List<ForumDto> forumDtos { get; set; }
        public List<ContentDto> contentDtos { get; set; }
        public List<GroupDto> groupDtos { get; set; }

        public AdminViewModel()
        {
            this.userDtos = new List<UserDto>();
            this.folderDtos = new List<FolderDto>();
            this.forumDtos = new List<ForumDto>();
            this.contentDtos = new List<ContentDto>();
            this.groupDtos = new List<GroupDto>();

        }

    }
}