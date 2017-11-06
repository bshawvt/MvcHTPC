using MvcHTPC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.ViewModels
{
    public class HomeViewModel
    {
        public bool isLoggedIn { get; set; }
        public UserDto userDto { get; set; }
        public List<FolderDto> folderDtos { get; set; }
        public List<ContentDto> contentDtos { get; set; }

        public HomeViewModel()
        {
            this.userDto = new UserDto();
            this.folderDtos = new List<FolderDto>();
            this.contentDtos = new List<ContentDto>();
        }
    }
}