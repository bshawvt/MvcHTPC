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
        public HomeViewModel()
        {
            this.userDto = new UserDto();
        }
    }
}