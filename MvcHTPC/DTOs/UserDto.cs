using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcHTPC.Models;
using static MvcHTPC.Models.DbModels.DbStaticEnums;

namespace MvcHTPC.DTOs
{
    public class UserDto
    {

        public long id { get; set; }
        public AccessLevel accessLevel { get; set; }
        public string groupIds { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime dateOfCreation { get; set; }
        public UserDto()
        {

        }
        public UserDto(users u)
        {
            this.id = u.id;
            this.accessLevel = u.accessLevel;
            this.groupIds = u.groupIds;
            this.username = u.username;
            this.email = u.email;
            this.dateOfCreation = u.dateOfCreation;

        }
        
    }
}