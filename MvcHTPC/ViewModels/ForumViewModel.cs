using MvcHTPC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.ViewModels
{
    public class ForumViewModel
    {
        public List<FolderDto> folderDtos { get; set; }
        public string lastModifiedUsername { get; set; }
        public ForumViewModel()
        {
            this.folderDtos = new List<FolderDto>();
            this.lastModifiedUsername = "";
        }
    }
}