using MvcHTPC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.ViewModels
{
    public class UserViewModel
    {
        public bool isLoggedIn { get; set; }
        public string test { get; set; }
        public UserDto userDto { get; set; }
        public UserViewModel()
        {
            this.userDto = new UserDto();
        }
        public UserViewModel(string t)
        {
            this.test = t;
        }
    }
}