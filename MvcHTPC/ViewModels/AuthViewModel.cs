using MvcHTPC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHTPC.ViewModels
{
    public class AuthViewModel
    {
        public List<string> errors { get; set; }
        public UserDto userDto { get; set; }



        public AuthViewModel()
        {
            errors = new List<string>();
        }
    }
}