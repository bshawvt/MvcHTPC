using Microsoft.AspNet.Identity;
using MvcHTPC.DTOs;
using MvcHTPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MvcHTPC.Models.DbModels.DbStaticEnums;

namespace MvcHTPC.Services
{
    public class UserService
    {
        private MvcHTPCContext db = new MvcHTPCContext();
        public AccessLevel GetAccess(long id)
        {
            var user = db.tblUsers.Find(id);
            return user.accessLevel;
        }
        public UserDto GetUserDtoById(long id)
        {
            var _user = db.tblUsers.Find(id);
            if (_user != null)
            {
                UserDto user = new UserDto(_user);
                return user;
            }
            return null;
        }
        public UserDto GetUserDtoByUsername(string username)
        {
            UserDto user = new UserDto(db.tblUsers.Where(x=>x.username.ToLower() == username.ToLower()).FirstOrDefault());
            return user;
        }
        public List<UserDto> GetUserDtos(string searchString, string amount, string pageNumber)
        {
            int i_amount = Convert.ToInt32(amount);
            int i_pageNumber = Convert.ToInt32(pageNumber);

            List<UserDto> dtoList = new List<UserDto>();
            foreach(var i in db.tblUsers.OrderByDescending(x => x.username.Contains(searchString)).Skip(i_pageNumber * i_amount).Take(i_amount).ToList())
            {
                dtoList.Add(new UserDto(i));
            }

            return dtoList;
        }
    }

}