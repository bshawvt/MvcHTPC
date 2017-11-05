using Microsoft.AspNet.Identity;
using MvcHTPC.Models;
using MvcHTPC.Services;
using MvcHTPC.Utilities;
using MvcHTPC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MvcHTPC.Models.DbModels.DbStaticEnums;

namespace MvcHTPC.Controllers
{
    public class AdminController : Controller
    {
        
        public ActionResult Index(string searchString, string amount, string pageNumber)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            long userId = Convert.ToInt64(User.Identity.GetUserId());

            AdminViewModel viewModel = new AdminViewModel();
            UserService userService = new UserService();
            if (userService.GetAccess(userId) != AccessLevel.ADMINISTRATOR)
                return RedirectToAction("Index", "Home");

            viewModel.userDtos = userService.GetUserDtos(searchString, amount, pageNumber);
            return View(viewModel);
        }

        private MvcHTPCContext db = new MvcHTPCContext(); // todo: adminservice.cs
        [HttpPost]
        public PartialViewResult CreateNotification(string title, string message, string id)
        {
            Debug.WriteLine("title: {0}, message: {1}, id: {2}", title, message, id);
            long userId = Convert.ToInt64(User.Identity.GetUserId());
            UserService userService = new UserService();
            long t_id = 0;
            if (userService.GetAccess(userId) == AccessLevel.ADMINISTRATOR)
            {
                db.tblNotifications.Add(new notifications
                {
                    dateOfCreation = DateTime.Now,
                    message = message,
                    title = title,
                    userId = t_id
                });
                db.SaveChanges();
            }
            return PartialView("Result");
        }
        [HttpPost]
        public PartialViewResult CreateForum(string title, string description, string groups, string state)
        {
            long userId = Convert.ToInt64(User.Identity.GetUserId());
            UserService userService = new UserService();
            if (userService.GetAccess(userId) == AccessLevel.ADMINISTRATOR)
            {
                Debug.WriteLine("title:{0}, description:{1}, groups: {2}, state: {3}", title, description, groups, state);
                var t_state = MyConvert.ToHiddenState(state);
                db.tblForums.Add(new forums
                {
                    dateOfCreation = DateTime.Today,
                    description = description,
                    groupIds = groups,
                    hidden = t_state,
                    title = title,
                    locked = false
                    
                });
                db.SaveChanges();
            }
            return PartialView("Result");
        }
    }
}