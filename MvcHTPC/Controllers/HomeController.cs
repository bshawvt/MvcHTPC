using Microsoft.AspNet.Identity;
using MvcHTPC.DTOs;
using MvcHTPC.Models;
using MvcHTPC.Services;
using MvcHTPC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcHTPC.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {

            HomeViewModel viewModel = new HomeViewModel();
            UserService userService = new UserService();
            FolderService fs = new FolderService();

            var user = userService.GetUserDtoById(Convert.ToInt64(User.Identity.GetUserId())); ;
            if (user != null)
            {
                Debug.WriteLine("user not null");
                if (User.Identity.IsAuthenticated)
                {
                    viewModel.userDto = user;
                    viewModel.folderDtos = fs.GetAllFoldersBelongingToUser(viewModel.userDto.id);
                }
            }
            else
            {
                Debug.WriteLine("User is totally null");
                //return RedirectToAction("Logout", "Auth");
            }
            return View(viewModel);
        }
        [AllowAnonymous]
        public ActionResult Progress()
        {
            return View("FeatureList");
        }

        [HttpPost]
        public ActionResult CreateFolder([System.Web.Http.FromBody]string title, [System.Web.Http.FromBody]string description)
        {
            FolderService fs = new FolderService();
            UserService us = new UserService();
            long userId = Convert.ToInt64(User.Identity.GetUserId());
            fs.CreateFolderByDto(us.GetUserDtoById(userId), title, description);
            return RedirectToAction("Index");
        }
    }
}